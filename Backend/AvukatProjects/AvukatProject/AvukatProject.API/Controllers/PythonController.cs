using Microsoft.AspNetCore.Mvc;
using AvukatProjectCore.Model;
using AvukatProjectCore.DTOs;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using AvukatProjectRepository;

namespace AvukatProject.API.Controllers
{
    public class PythonController : CustomBaseController
    {
        private readonly AppDbContext _context;


        public PythonController(AppDbContext context)
        {
            _context = context;

        }

        [HttpPost]
        public async Task<IActionResult> PostRequestAsync(QuestionsDto questionDto)
        {
            // Convert DTO to entity object
            var question = new Questions()
            {
                Question = questionDto.Question,
                LawyersId = questionDto.LawyersId,
                UsersId = questionDto.UsersId
            };
            //Avukat seçildiyse avukat nesnesi oluşturulması ve soruya atanması
            if (question.LawyersId.HasValue)
            {
                var lawyer = _context.Lawyers.Find(question.LawyersId.Value);
                if (lawyer == null)
                {
                    return NotFound("Avukat bulunamadı");
                }
                question.Lawyers = lawyer;
            }

            // Kullanıcı nesnesinin veritabanından alınması ve soruya atanması
            var user = _context.Users.Find(question.UsersId);
            if (user == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }
            PythonCode model = new PythonCode();
            var result = model.CallPyFunction(question);
            //Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);
            return Ok(result);
        }
    }
}
