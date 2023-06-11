using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvukatProjectCore.Model
{
    public class Oppressions:BaseEntity
    {
        public double Oppression { get; set; }
        public int OppressionQuestionId { get; set; }
        public Questions Question { get; set; }
    }
}
