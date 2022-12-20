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

        public DbSet<Species> Species { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<CharacterStats> CharacterStats { get; set; }

        public DbSet<Weapon> Weapons { get; set; }
    }
}
