using System.ComponentModel.DataAnnotations;

namespace StarWarsProject.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set;}

        public ICollection<Characters> Characters { get; set; }
    }
}
