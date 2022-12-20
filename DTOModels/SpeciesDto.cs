using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace StarWarsProject.ModelsDto
{
    public class SpeciesDto
    {
        public int SpeciesId { get; set; }
        public string SpeciesName { get; set;}
    }
}
