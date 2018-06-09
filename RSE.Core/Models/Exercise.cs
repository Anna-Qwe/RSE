using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE.Core.Models
{
    class Exercise
    {
        public int Id { get; set; }
        public Variant Variant { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public int Answer { get; set; }
        public string ImgURL { get; set; }
    }
}
