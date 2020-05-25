using Infestation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class HumanController : Controller
    {
        public IActionResult Index()
        {
            return BadRequest();
        }
    }
}
