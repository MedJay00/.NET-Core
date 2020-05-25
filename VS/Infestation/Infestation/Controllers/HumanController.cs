using Infestation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    public class HumanController : Controller
    {

        private InfestationContext _context { get; set; }
        public HumanController(InfestationContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            ViewData["human"]=_context.Humans.SingleOrDefault(human => human.Id == id);
            return View();
        }
        public IActionResult Country(int id)
        {
            ViewData["country"] = _context.Humans.SingleOrDefault(human => human.Id == id).Country.Name;
            return View();
        }
       
    }
}
