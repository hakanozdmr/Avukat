using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Model
{
    public class Questions : BaseEntity
    {
        public string Question { get; set; }
        public int? LawyersId { get; set; }
        public int UsersId { get; set; }
        public Lawyers Lawyers { get; set; }
        public Users Users { get; set; }
        public ICollection<Answers> Answers { get; set; }
        public ICollection<Oppressions> Oppressions { get; set; }

        public bool state { get; set; } = false;
    }
}
