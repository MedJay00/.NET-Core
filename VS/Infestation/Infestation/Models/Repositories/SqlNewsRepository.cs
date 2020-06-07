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
    }
}
