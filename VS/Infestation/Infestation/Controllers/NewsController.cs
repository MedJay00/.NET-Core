using Infestation.Models;
using Infestation.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Controllers
{
    
    public class NewsController : Controller
    {
        private INewsRepository _repository { get; set; }

        public NewsController(INewsRepository repository)
        {
            _repository = repository;
        }

        [Route("")]
        [Route("[controller]/[action]")]
        [Route("News/Index/{id?}")]
        public IActionResult Index()
        {
            
            ViewData["news"] = _repository.GetAllNews().ToList();
            return View();
        }

        
        public IActionResult Show(int newsId)
        {
           
            ViewData["news"] = _repository.GetAllNews().SingleOrDefault(news => news.Id == newsId);
            return View();
        }
    }
}
