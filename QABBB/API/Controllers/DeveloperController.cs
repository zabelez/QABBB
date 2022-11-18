using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DeveloperController : ControllerBase
    {
        private readonly QABBBContext _context;

        public DeveloperController(QABBBContext context)
        {
            _context = context;
        }

        // GET: api/Developer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Developer>>> GetDevelopers()
        {
          if (_context.Developers == null)
          {
              return NotFound();
          }
            return await _context.Developers.ToListAsync();
        }

        // GET: api/Developer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Developer>> GetDeveloper(int id)
        {
          if (_context.Developers == null)
          {
              return NotFound();
          }
            var developer = await _context.Developers.FindAsync(id);

            if (developer == null)
            {
                return NotFound();
            }

            return developer;
        }

        // PUT: api/Developer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeveloper(int id, Developer developer)
        {
            if (id != developer.IdDeveloper)
            {
                return BadRequest();
            }

            _context.Entry(developer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeveloperExists(id))
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

        // POST: api/Developer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Developer>> PostDeveloper(Developer developer)
        {
          if (_context.Developers == null)
          {
              return Problem("Entity set 'QABBBContext.Developers'  is null.");
          }
            _context.Developers.Add(developer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DeveloperExists(developer.IdDeveloper))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDeveloper", new { id = developer.IdDeveloper }, developer);
        }

        // // DELETE: api/Developer/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteDeveloper(int id)
        // {
        //     if (_context.Developers == null)
        //     {
        //         return NotFound();
        //     }
        //     var developer = await _context.Developers.FindAsync(id);
        //     if (developer == null)
        //     {
        //         return NotFound();
        //     }

        //     _context.Developers.Remove(developer);
        //     await _context.SaveChangesAsync();

        //     return NoContent();
        // }

        private bool DeveloperExists(int id)
        {
            return (_context.Developers?.Any(e => e.IdDeveloper == id)).GetValueOrDefault();
        }
    }
}
