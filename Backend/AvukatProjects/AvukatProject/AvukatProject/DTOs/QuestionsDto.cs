using AvukatProjectCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.DTOs
{
    public class QuestionsDto : BaseDto
    {
        public string Question { get; set; }
        public int LawyersId { get; set; }
        public int UsersId { get; set; }
        
    }
}
