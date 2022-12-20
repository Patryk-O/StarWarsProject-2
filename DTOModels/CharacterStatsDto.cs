using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarWarsProject.ModelsDto
{
    public class CharacterStatsDto
    {
        public int CharacterStatsId { get; set; }
        public int Health { get; set; } = Random.Shared.Next(1, 7) * 100;
        public int strength { get; set; } = Random.Shared.Next(1, 10) * 10;
        public int Force { get; set; } = Random.Shared.Next(1, 10) * 10;
        [Required]
        public int CharacterId { get; set; }
    }
}
