using AutoMapper;
using AvukatProjectCore.DTOs;
using AvukatProjectCore.Model;
using AvukatProjectCore.Services;
using AvukatProjectRepository;
using AvukatProjectService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AvukatProject.API.Controllers
{
    public class QuestionsController : CustomBaseController
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IService<Questions> _service;


        public QuestionsController(IMapper mapper, IService<Questions> service, AppDbContext context)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
            
        }
        [HttpPost]
        public async Task<ActionResult> AddQuestion(QuestionsDto questionDto)
        {
            // Convert DTO to entity object
            var users = await _context.Users.FirstOrDefaultAsync(s => s.Id == questionDto.UsersId);
            var lawyers = await _context.Lawyers.FirstOrDefaultAsync(s => s.Id == questionDto.LawyersId);
            
            //Avukat seçildiyse avukat nesnesi oluşturulması ve soruya atanması
                if (lawyers == null)
                {
                    return NotFound("Avukat bulunamadı");
                }

            // Kullanıcı nesnesinin veritabanından alınması ve soruya atanması
            if (users == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }

            var question = new Questions()
            {
                Question = questionDto.Question,
                LawyersId = questionDto.LawyersId,
                UsersId = questionDto.UsersId,
                Users = users,
                Lawyers = lawyers,
                CreatedDate = DateTime.UtcNow
            };
            PythonCode model = new PythonCode();
            var oppression = model.CallPyFunction(question);
            _context.Questions.Add(question);
            if(oppression != null)
            {
                if (oppression.Oppression != 0.00)
                {
                    _context.Oppressions.Add(oppression);
                    await _context.SaveChangesAsync();
                }
            }
           
            var similarQuestion = await _context.Oppressions.FirstOrDefaultAsync(s => s.Question.Id == question.Id);

            if (similarQuestion != null && similarQuestion.Oppression >= 0.35)
            {
                // Retrieve the answer for the similar question
                var similarAnswer = await _context.Answers.FirstOrDefaultAsync(a => a.QuestionsId == oppression.OppressionQuestionId);
                if(similarAnswer !=null) {
                    var answer = new Answers()
                    {
                        Answer = similarAnswer.Answer,
                        QuestionsId = question.Id,
                        UsersId = questionDto.UsersId
                    };
                    question.state = true;
                    _context.Answers.Add(answer);
                    await _context.SaveChangesAsync();
                }
                // Save the answer for the new question
                
            }
            await _context.SaveChangesAsync();
            return Ok(oppression);
        }
        
        [HttpGet("Lawyers/{lawyerId}")]
        public async Task<ActionResult> Get(int lawyerId)
        {
            var questions = _context.Questions.Include(q => q.Users).Include(q => q.Lawyers).Where(q => q.LawyersId == lawyerId)
                .Select(q => new {
                    QuestionId = q.Id,
                    QuestionText = q.Question,
                    q.CreatedDate,
                    q.state,
                    User = q.Users,
                    Lawyer = q.Lawyers
                });
            return Ok(questions);
        }
        [HttpPut]
        public async Task<IActionResult> Update(QuestionsDto questionsDto)
        {

            await _service.UpdateAsync(_mapper.Map<Questions>(questionsDto));
            return CreateActionResult(CustomResponseDto<QuestionsDto>.Success(204));
        }
        [HttpGet("Lawyers/Count/{lawyerId}")]
        public async Task<ActionResult> GetCountedQuestions(int lawyerId)
        {
            var questions = _context.Questions
            .Where(q => q.LawyersId == lawyerId)
            .Select(q => new {
                QuestionId = q.Id,
                QuestionText = q.Question,
                q.CreatedDate,
                q.state,
                User = q.Users,
                Lawyer = q.Lawyers
            })
            .ToList();
            var answeredQuestions = _context.Questions
            .Where(q => q.LawyersId == lawyerId && q.state == true)
            .Select(q => new {
                QuestionId = q.Id,
                QuestionText = q.Question,
                q.CreatedDate,
                q.state,
                User = q.Users,
                Lawyer = q.Lawyers
            })
            .ToList();
            int totalAnsweredQuestions = answeredQuestions.Count;
            int totalQuestions = questions.Count;
            return Ok(new
            {
                TotalAnsweredQuestions = totalAnsweredQuestions,
                TotalQuestions = totalQuestions
            });
        }
        [HttpGet("Lawyers/Answered/{lawyerId}")]
        public async Task<ActionResult> GetAnsweredQuestions(int lawyerId)
        {
            var answeredQuestions = _context.Questions
            .Where(q => q.LawyersId == lawyerId && q.state == true)
            .Select(q => new {
                QuestionId = q.Id,
                QuestionText = q.Question,
                q.CreatedDate,
                q.state,
                User = q.Users,
                Lawyer = q.Lawyers
            })
            .ToList();
            int totalAnsweredQuestions = answeredQuestions.Count;
            return Ok(answeredQuestions);
        }
        //[HttpGet("Lawyers/{lawyerId}")]  toplam soru sayısı ve cevaplanmış soruları getir
        //public async Task<ActionResult> Getq(int lawyerId)
        //{
        //    var questions = _context.Questions.Include(q => q.Lawyers).Where(q => q.LawyersId == lawyerId)
        //        .Select(q => new {
        //            QuestionId = q.Id,
        //            QuestionText = q.Question,
        //            q.CreatedDate,
        //            q.state,
        //            User = q.Users,
        //            Lawyer = q.Lawyers
        //        });
        //    return Ok(questions);
        //}
        [HttpGet("Lawyers/Danswered/{lawyerId}")]
        public async Task<ActionResult> GetDansweredQuestions(int lawyerId)
        {
            var answeredQuestions = _context.Questions
            .Where(q => q.LawyersId == lawyerId && q.state == false)
            .Select(q => new {
                QuestionId = q.Id,
                QuestionText = q.Question,
                q.CreatedDate,
                q.state,
                User = q.Users,
                Lawyer = q.Lawyers
            })
            .ToList();
            int totalAnsweredQuestions = answeredQuestions.Count;
            return Ok(answeredQuestions);
        }
        [HttpGet("User/{userId}")]
        public async Task<ActionResult> GetUserId(int userId)
        {
            var questions =  _context.Questions.Include(q => q.Users).Include(q => q.Lawyers).Where(q => q.UsersId == userId)
                .Select(q => new {
                    QuestionId = q.Id,
                    QuestionText = q.Question,
                    q.CreatedDate,
                    q.state,
                    User = q.Users,
                    Lawyer = q.Lawyers
                });
            return Ok(questions);
        }
        [HttpGet("User/Answered/{UsersId}")]
        public async Task<ActionResult> GetAnsweredQuestionsByUser(int UsersId)
        {
            var answeredQuestions = _context.Questions
            .Where(q => q.UsersId == UsersId && q.state == true)
            .Select(q => new {
                QuestionId = q.Id,
                QuestionText = q.Question,
                q.CreatedDate,
                q.state,
                User = q.Users,
                Lawyer = q.Lawyers
            })
            .ToList();
            int totalAnsweredQuestions = answeredQuestions.Count;
            return Ok(answeredQuestions);
        }
        [HttpGet("User/Danswered/{UsersId}")]
        public async Task<ActionResult> GetDansweredQuestionsByUser(int UsersId)
        {
            var answeredQuestions = _context.Questions
            .Where(q => q.UsersId == UsersId && q.state == false)
            .Select(q => new {
                QuestionId = q.Id,
                QuestionText = q.Question,
                q.CreatedDate,
                q.state,
                User = q.Users,
                Lawyer = q.Lawyers
            })
            .ToList();
            int totalAnsweredQuestions = answeredQuestions.Count;
            return Ok(answeredQuestions);
        }
        [HttpGet("{questionId}")]
        public IActionResult GetQuestionById(int questionId)
        {
            var question = _context.Questions.Include(q => q.Users).Include(q => q.Answers).Include(q => q.Lawyers).ThenInclude(l => l.Category).Where(q => q.Id == questionId).ToList();
            return Ok(question);
        }
    }
}
