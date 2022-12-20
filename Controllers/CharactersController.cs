using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWarsProject.Data;
using StarWarsProject.DTOModels;
using StarWarsProject.Models;
using StarWarsProject.ModelsDto;

namespace StarWarsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly StarWarsProjectContext _context;
        private readonly IMapper _mapper;

        public CharactersController(StarWarsProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
        {
            var Character = await _context.Characters
                .Include(c => c.Species)
                .Include(c => c.CharacterStats)
                .ToListAsync();
            return Ok(Character.Select(p => _mapper.Map<CharacterDto>(p)));
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<CharacterPostDto>>> PostCharacter(CharacterPostDto characterDto)
        {
            //Check if the species exist
            var species = await _context.Species.FindAsync(characterDto.SpeciesId);
            if (species == null)
                return NotFound("Species not found");
            //Create a Stats for Character
            var character = new Character
            {
                CharacterName = characterDto.CharacterName,
                Species = species
            };
            character.CharacterStats = new CharacterStats { CharacterId = character.CharacterId };
            _context.Characters.Add(character);

            await _context.SaveChangesAsync();
                        
            return Ok();

        }

    }
}
