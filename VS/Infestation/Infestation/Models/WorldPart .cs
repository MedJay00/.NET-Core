using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models
{
    public class WorldPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual List<Country> Country { get; set; }
    }
}
