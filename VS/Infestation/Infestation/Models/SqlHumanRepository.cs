using Infestation.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models
{
    public class SqlHumanRepository : ISqlHumanRepository
    {

        private InfestationContext _context { get; set; }
        public SqlHumanRepository(InfestationContext context) 
        {
            _context = context;
        }

        public void CreateHuman(Human human)
        {
            _context.Humans.Add(human);
            _context.SaveChangesAsync();
        }

        public void DeleteHuman(int id)
        {
            if (id != null)
            {
                Human human = _context.Humans.SingleOrDefault(_human => _human.Id == id);
                if (human != null)
                {
                   _context.Humans.Remove(human);
                   _context.SaveChangesAsync();
                    
                }
            }
        }

        public List<Human> GetAllHumans()
        {
            List<Human> humen = _context.Humans.ToList();

            return humen;
        }

        public Human GetHuman(int id)
        {
            if (id != null)
            {
                Human human = _context.Humans.SingleOrDefault(_human => _human.Id == id);
                return human;
            }
            return null;
        }

        public void ModifyHuman(Human human)
        {
            if (human != null)
            {
                _context.Humans.Update(human);
                _context.SaveChangesAsync();
            }
        }

        public List<Human> GetAllHumansInCountry(string countryName)
        {
            return _context.Countries.SingleOrDefault(country => country.Name == countryName).Humans;
        }
    }
}
