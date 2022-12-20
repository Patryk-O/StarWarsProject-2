﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarWarsProject.Data;
using StarWarsProject.Models;
using StarWarsProject.ModelsDto;

namespace StarWarsProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterStatsController : ControllerBase
    {
        private readonly StarWarsProjectContext _context;
        private readonly IMapper _mapper;

        public CharacterStatsController(StarWarsProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/CharacterStats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterStats>>> GetCharacterStats()
        {
            var Stats = await _context.CharacterStats.ToListAsync();
            return Ok(Stats.Select(p => _mapper.Map<CharacterStatsDto>(p)));
        }

        // GET: api/CharacterStats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterStats>> GetCharacterStats(int id)
        {
            var characterStats = await _context.CharacterStats.FindAsync(id);

            if (characterStats == null)
            {
                return NotFound();
            }

            return characterStats;
        }

        // PUT: api/CharacterStats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterStats(int id, CharacterStats characterStats)
        {
            if (id != characterStats.CharacterStatsId)
            {
                return BadRequest();
            }

            _context.Entry(characterStats).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterStatsExists(id))
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

        // POST: api/CharacterStats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CharacterStatsDto>> PostCharacterStats(CharacterStatsDto characterStatsdto)
        {
            var Character = await _context.Characters.FindAsync(characterStatsdto.CharacterId);

            if (Character == null)
                return NotFound();

            var characterStats = _mapper.Map<CharacterStats>(characterStatsdto); 
            
            _context.CharacterStats.Add(characterStats);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterStats", new { id = characterStats.CharacterStatsId }, characterStats);
        }

        // DELETE: api/CharacterStats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacterStats(int id)
        {
            var characterStats = await _context.CharacterStats.FindAsync(id);
            if (characterStats == null)
            {
                return NotFound();
            }

            _context.CharacterStats.Remove(characterStats);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterStatsExists(int id)
        {
            return _context.CharacterStats.Any(e => e.CharacterStatsId == id);
        }
    }
}
