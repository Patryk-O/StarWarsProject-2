using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace StarWarsProject.ModelsDto
{
    public class CharacterDto
    {
        public string CharacterName { get; set; }
            public int SpeciesId { get; set; }
        public int CharacterStatsId { get; set; }
    }
}
