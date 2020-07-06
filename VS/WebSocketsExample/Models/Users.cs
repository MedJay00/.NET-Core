using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebSocketsExample.Models
{
    public class Users
    {
        [Required]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Name must only countain")]
        public string Name { get; set; }
    }
}
