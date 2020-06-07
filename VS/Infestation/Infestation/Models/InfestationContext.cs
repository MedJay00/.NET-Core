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

        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorldPart>().HasData(
                new WorldPart { Id = 1, Name = "Australia" },
                new WorldPart { Id = 2, Name = "Asia" },
                new WorldPart { Id = 3, Name = "America" },
                new WorldPart { Id = 4, Name = "Antarctica" },
                new WorldPart { Id = 5, Name = "Africa" },
                new WorldPart { Id = 6, Name = "Europe" }
                );
        }

    }
}
