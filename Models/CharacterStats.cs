using System.ComponentModel.DataAnnotations;

namespace StarWarsProject.Models
{
    public class CharacterStats
    {
        [Key]
        public int CharacterStatsId { get; set; }
        [Required]
        public int Health { get; set; } = 100;
        [Required]
        [Range(0, 100)]
        public int strength { get; set; } = Random.Shared.Next(0, 100);
        [Required]
        [Range(0, 100)]
        public int Force { get; set; } = Random.Shared.Next(0, 100);
    }
}
