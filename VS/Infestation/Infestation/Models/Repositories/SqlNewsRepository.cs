using Infestation.Models;
using Infestation.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models.Repositories
{
    public class SqlNewsRepository : INewsRepository
    {
        private InfestationContext _context { get; set; }
        public SqlNewsRepository(InfestationContext context)
        {
            _context = context;
        }

        public IEnumerable<News> GetAllNews()
        {
            
            return _context.News;
        }

        public News GetNews(int id)
        {
            if (id != null)
            {
                News news = _context.News.FirstOrDefault(_news => _news.Id == id);
                return news;
            }
            return null;
        }

       

        public void CreateNews(News news)
        {
            _context.Add(news);
            _context.SaveChangesAsync();
        }

        public List<News> GetAllAuthorsNews(int authorsId)
        {
            List<News> allAuthorsNews = _context.News.Where(_news => _news.AuthorId == authorsId).ToList();

            return allAuthorsNews;

        }
    }
}
