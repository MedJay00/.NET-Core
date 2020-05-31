using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models.Repositories
{
    public interface ISqlHumanRepository
    {
        public List<Human> GetAllHumans();

        public Human GetHuman(int id);

        public void CreateHuman(Human human);

        public void ModifyHuman(Human human);

        public void DeleteHuman(int id);

        public List<Human> GetAllHumansInCountry(string countryName);


    }
}
