using RSE.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSE.Core
{
    class Answer
    {
        public int Id { get; set; }
        public string AnsDescription { get; set; }
        public Exercise Exercise { get; set; }
    }
}
