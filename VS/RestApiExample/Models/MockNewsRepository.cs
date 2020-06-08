using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestApiExample.Models
{
    public class MockNewsRepository : INewsRepository
    {

        public static string getListNews()
        {
            
            using (StreamReader sr = new StreamReader("newsData.txt"))
            {
               
                string json = sr.ReadToEnd();

                //News = JsonSerializer.Deserialize<List<News>>(json);
                //public List<News> News = JsonSerializer.Deserialize<List<News>>(json);
                //public List<News> News = JsonSerializer.Deserialize<List<News>>(sr.ReadToEnd());
                return json;
            }
        }

        public void setNews(List<News> _news)
        {
            using (StreamWriter sw = new StreamWriter("newsData.txt", false, System.Text.Encoding.Default))
            {

                sw.Write(JsonSerializer.Serialize<List<News>>(_news));
            }

        }

       // private static IBaseNews _iBaseNews { get; set; }

        

        public List<News> News = JsonSerializer.Deserialize<List<News>>(getListNews());


    //    public  List<News> News = new List<News>
    //{
    //    new News { Id = 0, Title = "Humanity finally colonized the Mercury!!", Text = "", AuthorName = "Jeremy Clarkson", IsFake = true},
    //    new News { Id = 1, Title = "Increase your lifespan by 10 years, every morning you need...", Text = "", AuthorName = "Svetlana Sokolova", IsFake = true},
    //    new News { Id = 2, Title = "Scientists estimed the time of the vaccine invension: it is a summer of 2021", Text = "", AuthorName = "John Jones", IsFake = false},
    //    new News { Id = 3, Title = "Ukraine reduces the cost of its obligations!", Text = "", AuthorName = "Cerol Denvers", IsFake = false},
    //    new News { Id = 4, Title = "A species were discovered in Africa: it is blue legless cat", Text = "", AuthorName = "Jimmy Felon", IsFake = true}
    //};


        public IEnumerable<News> GetAllNews(bool? _isFake)
        {
            
            if (_isFake==null)
                return News;

            return News.Where(news => news.IsFake == _isFake);
        }

        public News GetNews(int id)
        {

            News news = News.FirstOrDefault(news => news.Id == id);

            return news;
        }

        public void CreateNews(News news)
        {

            News.Add(news);

            setNews(News);
        }

        public void DeleteNews(int id)
        {

            News.Remove(News.FirstOrDefault(news => news.Id == id));
            setNews(News);
        }

        public void PutNews(News _news)
        {

            News.Remove(News.FirstOrDefault(news => news.Id == _news.Id));
            News.Add(_news);
            setNews(News);
        }

        public void PatchNews(int id, News _news)
        {

            News patchNews = News.FirstOrDefault((news => news.Id == id));

            if (patchNews == null || _news == null)
                return;

            if (_news.Title != null)
                patchNews.Title = _news.Title;

            if (_news.Text != null)
                patchNews.Text = _news.Text;

            if (_news.IsFake != null)
                patchNews.IsFake = _news.IsFake;

            if (_news.AuthorName != null)
                patchNews.AuthorName = _news.AuthorName;

            News.Remove(News.FirstOrDefault(news => news.Id == id));
            News.Add(patchNews);
            setNews(News);
        }

        
    }
}
