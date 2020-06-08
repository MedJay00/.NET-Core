using Microsoft.AspNetCore.Mvc;
using RestApiExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Controllers
{
    [ApiController]
    [Route("v1")]
    public class NewsController: ControllerBase
    {
        private INewsRepository _repository { get; }

        public NewsController(INewsRepository repository)
        {
            
            _repository = repository;
            
        }

        [HttpGet("News")]
        public IEnumerable<News> GetNews(bool? isFake=null)
        {
           return _repository.GetAllNews(isFake);
        }


        [HttpPost("News")]
        public void CreateNews(News news)
        {
            _repository.CreateNews(news);
        }

        [HttpDelete("News")]
        public void DeleteNews(int id)
        {
            _repository.DeleteNews(id);
        }

        [HttpPut("News")]
        public void PutNews(News news)
        {
            _repository.PutNews(news);
        }

        [HttpPatch("News")]
        public void PatchNews(int id,News news)
        {
            _repository.PatchNews(id,news);
        }



    }
}
