using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiExample.Models
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAllNews(bool? isFake);

        public News GetNews(int id);

        void CreateNews(News news);

        void DeleteNews(int id);

        void PutNews(News _news);

        void PatchNews(int id, News _news);



    }
}
