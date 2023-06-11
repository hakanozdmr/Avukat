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
    
    public class CategoriesController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly IService<Category> _service;
        private readonly ICategoryService categoryService;
        private readonly AppDbContext _context;

        public CategoriesController(IMapper mapper, IService<Category> service, ICategoryService categoryService, AppDbContext context)
        {
            _mapper = mapper;
            _service = service;
            this.categoryService = categoryService;
            _context = context;
        }
        [HttpGet("{id}/lawyers")]
        public async Task<ActionResult<IEnumerable<LawyersDto>>> GetLawyersByCategoryId(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            //var lawyers = await _context.Lawyers
            //    .Where(l => l.CategoryId == id)
            //    .Select(l => new LawyersDto
            //    {
            //        Id = l.Id,
            //        Name = l.Name,
            //        Mail = l.Mail,
            //        About = l.About,
            //        Photograph = l.Photograph,
            //        Password = l.Password,
            //        CategoryId = l.CategoryId
            //    })
            //    .ToListAsync();
            var lawyers = _context.Lawyers.Include(l => l.Category).Where(l => l.CategoryId == id).ToList();
            if (!lawyers.Any())
            {
                return NoContent();
            }

            return Ok(lawyers);
        }
        
        [HttpGet]
        public async Task<IActionResult> All()
        {

            var category = await _service.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(category.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryDto = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
              
            };

            return Ok(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var category = await _service.AddAsync(_mapper.Map<Category>(categoryDto));
            var categoryDtos = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoryDtos));
        }
        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {

            await _service.UpdateAsync(_mapper.Map<Category>(categoryDto));
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {

            var category = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(204));
        }
    }
}
