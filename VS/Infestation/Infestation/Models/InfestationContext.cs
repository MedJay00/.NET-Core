using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infestation.Models
{
    public class InfestationContext : DbContext
    {
        public InfestationContext(DbContextOptions options)
            :base(options)
        {

        }
          
        public DbSet<Country> Countries { get; set; }
        public DbSet<Human> Humans { get; set; }

       
    }
}
