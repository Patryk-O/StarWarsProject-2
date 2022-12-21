using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
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

        [HttpGet("id")]
        public async Task<ActionResult<CharacterDto>> GetCharacterById(int id)
        {
            var character = await _context.Characters
                .Include(p => p.Species)
                .Include(p => p.CharacterStats)
                .FirstOrDefaultAsync(p => p.CharacterId == id);
            if (character == null)
                return NotFound();


            return Ok(_mapper.Map<CharacterDto>(character));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterDto characterDto)
        {
            var previesCharacter = await _context.Characters.FindAsync(id);
            if (previesCharacter == null)
            {
                return NotFound();
            }

            var character = _mapper.Map<Character>(characterDto);
            previesCharacter.CharacterName = character.CharacterName;
            previesCharacter.CharacterStats = character.CharacterStats;
            previesCharacter.Species = character .Species;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
