using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StarWarsProject.Models;

namespace StarWarsProject.Data
{
    public class StarWarsProjectContext : DbContext
    {
        public StarWarsProjectContext (DbContextOptions<StarWarsProjectContext> options)
            : base(options)
        {
        }

        public DbSet<StarWarsProject.Models.Species> Species { get; set; }

        public DbSet<StarWarsProject.Models.Characters> Characters { get; set; }

        public DbSet<StarWarsProject.Models.CharacterStats> CharacterStats { get; set; }
    }
}
