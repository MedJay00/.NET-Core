using Infestation.Models;
using Infestation.Models.Repositories;
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

        //private InfestationContext _context { get; set; }
        //public HumanController(InfestationContext context)
        //{
        //    _context = context;
        //}

        //public IActionResult Index(int humanId)
        //{
        //    List<Human> humen = null;

        //    if (humanId == 0)
        //    {
        //        humen = _context.Humans.ToList();

        //    }
        //    else
        //    {
        //        humen = new List<Human>(1);
        //        humen.Add(_context.Humans.SingleOrDefault(human => human.Id == humanId));
        //    }

        //    ViewData["human"] = humen;
        //    return View();
        //}
        //public IActionResult Country(string countryName)
        //{
        //    ViewData["country"] = _context.Countries.SingleOrDefault(country => country.Name == countryName).Humans;
        //    return View();
        //}

        private ISqlHumanRepository _sqlHumanRepository { get; set; }
        public HumanController(ISqlHumanRepository sqlHumanRepository)
        {
            _sqlHumanRepository = sqlHumanRepository;
        }

        

        public IActionResult Index(int humanId)
        {
            List<Human> humen = null;

            if (humanId == 0)
            {
                humen = _sqlHumanRepository.GetAllHumans();

            }
            else
            {
                humen = new List<Human>(1);
                humen.Add(_sqlHumanRepository.GetHuman(humanId));
            }

            ViewData["human"] = humen;
            return View();
        }
        public IActionResult Country(string countryName)
        {
            ViewData["country"] = _sqlHumanRepository.GetAllHumansInCountry(countryName);

            return View();
        }

    }
}
