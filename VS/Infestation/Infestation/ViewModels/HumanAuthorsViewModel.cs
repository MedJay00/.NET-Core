using Infestation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.ViewModels
{
    public class HumanAuthorsViewModel
    {
        public int AuthorId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public int NewsCount { get; set; }
    }
}
