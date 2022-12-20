using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace StarWarsProject.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [Required]
        public string CharacterName { get; set; }

        // Species information
        [Required]
        [ForeignKey("SpeciesId")]
        public int SpeciesId { get; set; }
        [JsonIgnore]
        public Species Species { get; set; }

        //Character Stats
        [Required]
        [ForeignKey("CharacterStatsId")]
        public int CharecterStatsId { get; set; }
        [JsonIgnore]
        public CharacterStats CharacterStats { get; set; }
    }
}
