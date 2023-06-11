using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using AvukatProjectService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AvukatProject.API.Controllers
{
    public class AnswersController : CustomBaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IService<Answers> _service;

        public AnswersController(IMapper mapper, IService<Answers> service, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _service = service;

        }
        [HttpPut]
        public async Task<IActionResult> Update(AnswersDto answersDto)
        {
            //var users = await _context.Users.FirstOrDefaultAsync(s => s.Id == answersDto.UsersId);
            //var questions = await _context.Questions.FirstOrDefaultAsync(s => s.Id == answersDto.QuestionsId);
            //var answer = new Answers
            //{
            //    Answer = answersDto.Answer,
            //    QuestionsId = answersDto.QuestionsId,
            //    UsersId = answersDto.UsersId,
            //    Users = users,
            //    Questions = questions

            //};

            //_context.Answers.Update(answer);
            //_context.SaveChanges();
            //return Ok(answer);
            await _service.UpdateAsync(_mapper.Map<Answers>(answersDto));
            return CreateActionResult(CustomResponseDto<AnswersDto>.Success(204));
           
        }
        [HttpPost]
        public async Task<ActionResult> PostAnswers(AnswersDto answersDto)
        {
            var users = await _context.Users.FirstOrDefaultAsync(s => s.Id == answersDto.UsersId);
            var questions = await _context.Questions.FirstOrDefaultAsync(s => s.Id == answersDto.QuestionsId);
            if (questions == null)
            {
                return NotFound("Soru bulunamadı");
            }

            // Kullanıcı nesnesinin veritabanından alınması ve soruya atanması
            if (users == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            if (questions != null)
            {
                questions.state = true;
                await _context.SaveChangesAsync();
            }
            var answer = new Answers
            {
                Answer = answersDto.Answer,
                QuestionsId = answersDto.QuestionsId,
                UsersId = answersDto.UsersId,
                Users = users,
                Questions = questions,
                Rating = answersDto.Rating

            };

            // Avukat seçildiyse avukat nesnesi oluşturulması ve soruya atanması
            //if (answer.LawyersIdd.HasValue)
            //{
            //    var lawyer = _context.Lawyers.Find(answer.LawyersIdd.Value);
            //    if (lawyer == null)
            //    {
            //        return NotFound("Avukat bulunamadı");
            //    }
            //    answer.Lawyers = lawyer;
            //}

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return Ok(answer);
        }
        [HttpGet("User/{userId}")]
        public IActionResult Get(int userId)
        {
            var answers = _context.Answers.Where(q => q.UsersId == userId).ToList();
            return Ok(answers);
        }

        [HttpGet("Question/{questionId}")]
        public IActionResult GetAnswerByQuestionId(int questionId)
        {
            var answer = _context.Answers.Include(q => q.Questions).Where(q => q.QuestionsId == questionId).ToList();
            if (answer == null)
            {
                return NotFound("Soru bulunamadı");
            }
            return Ok(answer);
        }
        [HttpGet("{answerId}")]
        public IActionResult GetAnswerById(int answerId)
        {
            var answer = _context.Answers.Where(q => q.Id == answerId).ToList();
            return Ok(answer);
        }

    }
}
