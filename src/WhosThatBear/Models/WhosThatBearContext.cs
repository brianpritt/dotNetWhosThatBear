using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WhosThatBear.Models
{
    public class WhosThatBearContext : DbContext
    {
        public virtual DbSet<Sighting> Sightings { get; set; }
        public virtual DbSet<Species> Species { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WhosThatBear;integrated security=True");
        }
    }
}
