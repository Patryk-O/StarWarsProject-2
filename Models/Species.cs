using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace StarWarsProject.Models
{
    public class Species
    {
        [Key]
        public int SpeciesId { get; set; }
        [Required]
        public string SpeciesName { get; set;}

        //Relation One-Many
        [JsonIgnore]
        public ICollection<Character> Character { get; set;}
    }
}
