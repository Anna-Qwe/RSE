using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE.Core.Models
{
    public class Variant
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public List<Exercise> Exercises { get; set; }
    }
}
