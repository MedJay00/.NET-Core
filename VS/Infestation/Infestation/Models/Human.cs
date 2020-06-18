using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models
{
    public class Human
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Name must only countain")]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Range(1,150,ErrorMessage ="Age is out available")]
        public int Age { get; set; }

        [Required]
        public bool IsSick { get; set; }

        [Required]
        public string Gender { get; set; }


        [Range(1, 7, ErrorMessage = "CountryId is out available")]
        public int CountryId { get; set; }     
        public virtual Country Country { get; set; }
    }
}
