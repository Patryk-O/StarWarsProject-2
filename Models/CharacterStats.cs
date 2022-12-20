using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StarWarsProject.Models
{
    public class CharacterStats
    {
        [Key]
        public int CharacterStatsId { get; set; }
        [Required]
        public int Health { get; set; } = Random.Shared.Next(1, 10) * 100;
        [Required]
        [Range(0, 100)]
        public int strength { get; set; } = Random.Shared.Next(1, 10) * 10;
        [Required]
        [Range(0, 100)]
        public int Force { get; set; } = Random.Shared.Next(1, 10) * 10;

        //Relation One-One
        [ForeignKey("CharacterId")]
        [Required]
        public int CharacterId { get; set; }
        [JsonIgnore]
        public Character Character { get; set; }
    }
}
