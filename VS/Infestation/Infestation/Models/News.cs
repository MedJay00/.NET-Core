using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z0-9]{,50}*$", ErrorMessage = "Title must only countain")]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        public bool IsFake { get; set; }

        [Range(1, 20, ErrorMessage = "CountryId is out available")]
        public int AuthorId { get; set; }

        public virtual Human Author { get; set; }
    }
}
