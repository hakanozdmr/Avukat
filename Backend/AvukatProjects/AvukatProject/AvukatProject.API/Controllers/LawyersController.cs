using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using AvukatProjectService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvukatProject.API.Controllers
{
    
    public class LawyersController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Lawyers> _lawyers;
        private readonly ILawyersService lawyersService;
        private readonly AppDbContext _context;

        public LawyersController(IMapper mapper, IService<Lawyers> lawyers, ILawyersService lawyersService, AppDbContext context)
        {
            _mapper = mapper;
            _lawyers = lawyers;
            this.lawyersService = lawyersService;
            _context = context;
        }
        
        [HttpGet]
        public async Task<IActionResult> All()
        {

            var lawyer = await _lawyers.GetAllAsync();
            var lawyerDtos = _mapper.Map<List<LawyersDto>>(lawyer.ToList());
            return CreateActionResult(CustomResponseDto<List<LawyersDto>>.Success(200, lawyerDtos));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<LawyersDto>> GetLawyerById(int id)
        {
            var lawyer = await _context.Lawyers.FindAsync(id);

            if (lawyer == null)
            {
                return NotFound();
            }

            var lawyerDto = new LawyersDto
            {
                Id = lawyer.Id,
                Name = lawyer.Name,
                Email = lawyer.Email,
                About = lawyer.About,
                Photograph = lawyer.Photograph,
                Password = lawyer.Password,
                CategoryId = lawyer.CategoryId
            };

            return Ok(lawyerDto);
        }
        [HttpGet("Rating/")]
        public async Task<ActionResult<LawyersDto>> GetLawyerWithRating()
        {
            var lawyersWithRating = _context.Lawyers
            .Select(lawyer => new
            {
                Lawyer = lawyer,
                AverageRating = _context.Answers
                    .Join(
                        _context.Questions,
                        a => a.QuestionsId,
                        q => q.Id,
                        (a, q) => new { Answer = a, Question = q }
                    )
                    .Where(aq => aq.Question.LawyersId == lawyer.Id && aq.Answer.Rating > 0)
                    .Average(aq => (double?)aq.Answer.Rating) ?? 0,
                RatingedQuestions = _context.Answers
                    .Join(
                        _context.Questions,
                        a => a.QuestionsId,
                        q => q.Id,
                        (a, q) => new { Answer = a, Question = q }
                    )
                    .Where(aq => aq.Question.LawyersId == lawyer.Id && aq.Answer.Rating > 0)
                    .Count(),
                TotalQuestions = _context.Questions
                    .Count(q => q.LawyersId == lawyer.Id),
                AnsweredQuestions = _context.Answers
            .Join(
                _context.Questions,
                a => a.QuestionsId,
                q => q.Id,
                (a, q) => new { Answer = a, Question = q }
            )
            .Count(aq => aq.Question.LawyersId == lawyer.Id)
            })
            .ToList();

                    foreach (var item in lawyersWithRating)
                    {
                        item.Lawyer.AverageRating = item.AverageRating;
                        item.Lawyer.RatingedQuestions = item.RatingedQuestions;
                        item.Lawyer.TotalQuestions = item.TotalQuestions;
                        item.Lawyer.AnsweredQuestions = item.AnsweredQuestions;
            }

            _context.SaveChanges();

            return Ok(lawyersWithRating);
        }


        [HttpPost]
        public async Task<IActionResult> Save(LawyersDto lawyersDto)
        {
            var lawyer = await _lawyers.AddAsync(_mapper.Map<Lawyers>(lawyersDto));
            var lawyerDtos = _mapper.Map<LawyersDto>(lawyer);
            return CreateActionResult(CustomResponseDto<LawyersDto>.Success(201, lawyerDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(LawyersDto lawyersDto)
        {

            await _lawyers.UpdateAsync(_mapper.Map<Lawyers>(lawyersDto));
            return CreateActionResult(CustomResponseDto<LawyersDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {

            var lawyer = await _lawyers.GetByIdAsync(id);
            await _lawyers.RemoveAsync(lawyer);
            return CreateActionResult(CustomResponseDto<LawyersDto>.Success(204));
        }

        [HttpGet("{id}/categories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategoriesByLawyerId(int id)
        {
            var lawyer = await _context.Lawyers.FindAsync(id);

            if (lawyer == null)
            {
                return NotFound();
            }

            var categories = await _context.Categories
                .Where(c => c.Lawyers.Any(l => l.Id == id))
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            if (!categories.Any())
            {
                return NoContent();
            }

            return Ok(categories);
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<LawyersDto>> GetLawyerByCategoryId(int categoryId)
        {
            var lawyers = _context.Lawyers.Where(q => q.CategoryId == categoryId).ToList();

            if (lawyers == null)
            {
                return NotFound();
            }

            return Ok(lawyers);
        }
        [HttpGet("ListOtherLawyers/{lawyerId}")]
        public async Task<ActionResult<IEnumerable<LawyersDto>>> GetLawyersByCategoryId(int lawyerId)
        {
            var lawyer = await _lawyers.GetByIdAsync(lawyerId);
            if (lawyer == null)
            {
                return NotFound();
            }
            var otherLawyers = await _context.Lawyers
            .Include(l => l.Category)
            .Where(l => l.CategoryId == lawyer.CategoryId && l.Id != lawyer.Id)
            .ToListAsync();

            if (otherLawyers == null)
            {
                return NotFound();
            }

            return Ok(otherLawyers);
        }

    }
}
