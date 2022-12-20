using StarWarsProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace StarWarsProject.ModelsDto
{
    public class CharacterDto
    {
        public string CharacterName { get; set; }
        public SpeciesDto Species { get; set; }
        public CharacterStatsDto CharacterStats { get; set; }
    }
}
