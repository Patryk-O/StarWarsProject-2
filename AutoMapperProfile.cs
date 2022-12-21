using AutoMapper;
using StarWarsProject.DTOModels;
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

            CreateMap<Character, CharacterDto>();
            CreateMap<CharacterDto, Character>();

            CreateMap<Species, SpeciesPostDto>();
            CreateMap<SpeciesPostDto, Species>();

            CreateMap<CharacterStats, CharacterStatsPostDto>();
            CreateMap<CharacterStatsPostDto, CharacterStats>();

            CreateMap<Character, CharacterPostDto>();
            CreateMap<CharacterPostDto, Character>();

            CreateMap<Weapon, WeaponDto>();
            CreateMap<WeaponDto, Weapon>();

        }
    }
}
