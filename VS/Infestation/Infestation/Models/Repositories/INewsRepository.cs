using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models.Repositories
{
    public interface INewsRepository
    {
        public IEnumerable<News> GetAllNews();
    }
}
