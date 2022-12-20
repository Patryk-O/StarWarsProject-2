using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace StarWarsProject.Models
{
    public class CharacterStats
    {
        [Key]
        public int CharacterStatsId { get; set; }
        [NotNull]
        public int Health { get; set; } = Random.Shared.Next(1, 10) * 100;
        [NotNull]
        [Range(0, 100)]
        public int strength { get; set; } = Random.Shared.Next(1, 10) * 10;
        [NotNull]
        [Range(0, 100)]
        public int Force { get; set; } = Random.Shared.Next(1, 10) * 10;

        //Relation One-One
        [JsonIgnore]
        public Character Character { get; set; }
        public int CharacterId { get; set; }
    }
}
