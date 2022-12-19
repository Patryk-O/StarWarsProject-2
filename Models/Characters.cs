using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StarWarsProject.Models
{
    public class Characters
    {
        [Key]
        public int CharacterId { get; set; }
        [Required]
        public string CharacterName { get; set; }

        [Required]
        //Foreign key Species
        public int SpeciesId { get; set; }
        [Required]
        // Species information
        public Species Species { get; set; }

        [Required]
        //Character Stats
        public int CharacterStatsId { get; set; }
    }
}
