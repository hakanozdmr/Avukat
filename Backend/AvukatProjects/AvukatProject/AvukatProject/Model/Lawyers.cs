using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Model
{
    public class Lawyers : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string Photograph { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }

        public double? AverageRating { get; set; }

        public int? RatingedQuestions { get; set; }

        public int? TotalQuestions { get; set; }

        public int? AnsweredQuestions { get; set; }
        public int? RoleId { get; set; }
        public Category Category { get; set; }

        public Role Role { get; set; }
        public ICollection<Questions> Questions { get; set; }

       


    }
}
