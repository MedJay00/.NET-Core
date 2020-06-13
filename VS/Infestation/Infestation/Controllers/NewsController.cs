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

        
        public IActionResult Index(int id)
        {

            List<News> news = null;

            if (id == -1)
            {
                news = _repository.GetAllNews().ToList();

            }
            else
            {
                news = new List<News>
                {
                    _repository.GetNews(id)
                };
            }

            return View(news);

        }

        public IActionResult Author (int authorsId)
        {
            List<News> aNews=_repository.GetAllAuthorsNews(authorsId);
            

            return View(aNews);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(News news)
        {
            _repository.CreateNews(news);
            return View();
        }
    }
}
