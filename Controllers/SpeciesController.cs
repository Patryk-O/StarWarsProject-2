using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    public class SpeciesController : ControllerBase
    {
        private readonly StarWarsProjectContext _context;
        private readonly IMapper _mapper;

        public SpeciesController(StarWarsProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Species
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpeciesDto>>> GetSpecies()
        {
            return Ok(_context.Species.Select(p => _mapper.Map<SpeciesDto>(p)));
        }

        // GET: api/Species/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Species>> GetSpecies(int id)
        {
            var species = await _context.Species.FindAsync(id);

            if (species == null)
            {
                return NotFound();
            }

            return species;
        }

        // PUT: api/Species/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecies(int id, SpeciesDto speciesDto)
        {
            if (id != speciesDto.SpeciesId)
            {
                return BadRequest();
            }
            var species = _mapper.Map<Species>(speciesDto);
            _context.Entry(species).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeciesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Species
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SpeciesPostDto>> PostSpecies(SpeciesPostDto speciesDto)
        {
            var ifexist = await _context.Species.Where(p => p.SpeciesName == speciesDto.SpeciesName).ToListAsync();
            if (ifexist.Count != 0)
                return BadRequest("Species exist");
            var species = _mapper.Map<Species>(speciesDto);
            _context.Species.Add(species);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Species/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecies(int id)
        {
            var species = await _context.Species.FindAsync(id);
            if (species == null)
            {
                return NotFound();
            }

            _context.Species.Remove(species);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpeciesExists(int id)
        {
            return _context.Species.Any(e => e.SpeciesId == id);
        }
    }
}
