using System.ComponentModel.DataAnnotations;

namespace StarWarsProject.Models
{
    public class Characters
    {
        [Key]
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }

        //Foreign key Species
        public int SpeciesId { get; set; }
        // Species information
        public Species Species { get; set; }
    }
}
