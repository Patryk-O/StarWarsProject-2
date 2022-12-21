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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Species.Add(new Species { SpeciesId = 1, SpeciesName = "human" });
            Species.Add(new Species { SpeciesId = 2, SpeciesName = "Wookie" });

            Weapons.Add(new Weapon { WeaponId = 1, Damage = 30, Name = "Blaster" });
            Weapons.Add(new Weapon { WeaponId = 1, Damage = 30, Name = "Blaster" });

        }
        public DbSet<Species> Species { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<CharacterStats> CharacterStats { get; set; }

        public DbSet<Weapon> Weapons { get; set; }
    }
}
