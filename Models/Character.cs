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
        public Species Species { get; set; }

        //Character Stats
        public CharacterStats CharacterStats { get; set; }

        //Character Weapons
        public ICollection<Weapon> Weapons { get; set; }
    }
}
