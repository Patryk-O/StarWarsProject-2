using AutoMapper;
using StarWarsProject.Models;
using StarWarsProject.ModelsDto;

namespace StarWarsProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Species, SpeciesDto>();
            CreateMap<SpeciesDto, Species>();

            CreateMap<CharacterStats, CharacterStatsDto>();
            CreateMap<CharacterStatsDto, CharacterStats>();
        }
    }
}
