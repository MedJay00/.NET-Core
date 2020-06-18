using Infestation.Models;
using Infestation.Models.Repositories;
using Infestation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        private IHumanRepository _iHumanRepository { get; set; }
        public HumanController(IHumanRepository iHumanRepository)
        {
            _iHumanRepository = iHumanRepository;
        }

        
        [AllowAnonymous]
        public IActionResult Index(int humanId, string? countryName)
        {
            
                List<Human> humen = null;

            if (humanId == 0)
            {
                humen = _iHumanRepository.GetAllHumans();

            }
            else if (countryName != null)
            {
                humen = _iHumanRepository.GetAllHumansInCountry(countryName);
            }
            else
            {
                humen = new List<Human>(1);
                humen.Add(_iHumanRepository.GetHuman(humanId));
            }
                
            return View(humen);
        }

        [AllowAnonymous]
        public IActionResult Country(string _countryName)
        {
            //ViewData["humen"] = _iHumanRepository.GetAllHumansInCountry(countryName);
            return RedirectToAction("Index", "Human",new { humanId = 2, countryName= _countryName });
            //return View(_iHumanRepository.GetAllHumansInCountry(countryName));
        }

        [AllowAnonymous]
        public IActionResult Authors([FromServices] INewsRepository newsRepository, int AuthorsId=0) 
        {
            var humans = _iHumanRepository.GetAllHumans().ToList();
            var news = newsRepository.GetAllNews().ToList();
            var viewModels = new List<HumanAuthorsViewModel>();

            if (AuthorsId != 0)
            {
                var human = humans.FirstOrDefault(_human => _human.Id == AuthorsId);
                var viewModel = new HumanAuthorsViewModel();
                viewModel.AuthorId = human.Id;
                viewModel.FirstName = human.FirstName;
                viewModel.LastName = human.LastName;

                viewModel.NewsCount = news.Count(news => news.AuthorId == human.Id);

                viewModels.Add(viewModel);


                return View(viewModels);
            }

            foreach (var human in humans)
            {
                var viewModel = new HumanAuthorsViewModel();
                viewModel.AuthorId = human.Id;
                viewModel.FirstName = human.FirstName;
                viewModel.LastName = human.LastName;

                viewModel.NewsCount = news.Count(news=>news.AuthorId==human.Id);

                viewModels.Add(viewModel);
            }
            
            return View(viewModels);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Human human)
        {
            if(ModelState.IsValid)
                _iHumanRepository.CreateHuman(human);

            return View();
        }

        //Id=2&FirstName=Nikola&LastName=Gogol&type=47&IsSick=on&Gender=Male&CountryId=5
    }
}

