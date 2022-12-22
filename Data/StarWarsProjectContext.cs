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
            modelBuilder.Entity<Species>()
                .HasData(
                new Species
                {
                    SpeciesId = 1,
                    SpeciesName = "Human",
                },
                new Species
                {
                    SpeciesId = 2,
                    SpeciesName = "Wookie"
                },
                new Species
                {
                    SpeciesId= 3,
                    SpeciesName = "Jawa"
                });

            modelBuilder.Entity<Weapon>()
                .HasData(
                new Weapon
                {
                    WeaponId = 1,
                    Damage = 100,
                    Name = "Ligthsaber"
                },
                new Weapon
                {
                    WeaponId = 2,
                    Damage = 30,
                    Name = "Blaster"
                },
                new Weapon
                {
                    WeaponId = 3,
                    Damage = 20,
                    Name = "Blaster Pistol"
                });
        }
        public DbSet<Species> Species { get; set; }

        public DbSet<Character> Characters { get; set; }

        public DbSet<CharacterStats> CharacterStats { get; set; }

        public DbSet<Weapon> Weapons { get; set; }
    }
}
