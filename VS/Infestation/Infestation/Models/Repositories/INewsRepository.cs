using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models.Repositories
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAllNews();

        public News GetNews(int id);

        public List<News> GetAllAuthorsNews(int authorsId);

        public void CreateNews(News news);
       
    }
}
