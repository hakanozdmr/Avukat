using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.DTOs
{
    public class LawyersDto : BaseDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string Photograph { get; set; }
        public string Password { get; set; }
        public int CategoryId { get; set; }
    }
}
