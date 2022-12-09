using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QABBB.Data;
using QABBB.Models;

namespace QABBB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlatformController : ControllerBase
    {
        private readonly QABBBContext _context;

        public UserPlatformController(QABBBContext context)
        {
            _context = context;
        }

        // GET: api/UserPlatform
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserPlatform>>> GetUserPlatforms()
        {
          if (_context.UserPlatforms == null)
          {
              return NotFound();
          }
            return await _context.UserPlatforms.ToListAsync();
        }

        // GET: api/UserPlatform/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserPlatform>> GetUserPlatform(int id)
        {
          if (_context.UserPlatforms == null)
          {
              return NotFound();
          }
            var userPlatform = await _context.UserPlatforms.FindAsync(id);

            if (userPlatform == null)
            {
                return NotFound();
            }

            return userPlatform;
        }

        // PUT: api/UserPlatform/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserPlatform(int id, UserPlatform userPlatform)
        {
            if (id != userPlatform.IdUserPlatform)
            {
                return BadRequest();
            }

            _context.Entry(userPlatform).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPlatformExists(id))
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

        // POST: api/UserPlatform
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserPlatform>> PostUserPlatform(UserPlatform userPlatform)
        {
          if (_context.UserPlatforms == null)
          {
              return Problem("Entity set 'QABBBContext.UserPlatforms'  is null.");
          }
            _context.UserPlatforms.Add(userPlatform);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserPlatform", new { id = userPlatform.IdUserPlatform }, userPlatform);
        }

        // DELETE: api/UserPlatform/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserPlatform(int id)
        {
            if (_context.UserPlatforms == null)
            {
                return NotFound();
            }
            var userPlatform = await _context.UserPlatforms.FindAsync(id);
            if (userPlatform == null)
            {
                return NotFound();
            }

            _context.UserPlatforms.Remove(userPlatform);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserPlatformExists(int id)
        {
            return (_context.UserPlatforms?.Any(e => e.IdUserPlatform == id)).GetValueOrDefault();
        }
    }
}
