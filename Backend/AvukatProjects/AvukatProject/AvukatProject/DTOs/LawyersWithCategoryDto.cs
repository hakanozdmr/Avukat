using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.DTOs
{
    public class LawyersWithCategoryDto:LawyersDto
    {
        public CategoryDto Category { get; set; }
    }
}
