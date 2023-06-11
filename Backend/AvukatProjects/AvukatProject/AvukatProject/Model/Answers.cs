using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Model
{
    public class Answers:BaseEntity
    {
        public string Answer { get; set; }
        public int QuestionsId { get; set; }
        public int? Rating { get; set; }
        public Questions Questions { get; set; }
        public int UsersId { get; set; }
        public Users Users { get; set; }
    }
}
