using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeServiceApp.Models;

namespace HomeServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAdministrationController : ControllerBase
    {
        private readonly HomeServiceDBContext _context;

        public SystemAdministrationController(HomeServiceDBContext context)
        {
            _context = context;
        }

        // GET: api/SystemAdministration
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SystemAdministration>>> GetSystemAdministrations()
        {
          if (_context.SystemAdministrations == null)
          {
              return NotFound();
          }
            return await _context.SystemAdministrations.ToListAsync();
        }

        // GET: api/SystemAdministration/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SystemAdministration>> GetSystemAdministration(int id)
        {
          if (_context.SystemAdministrations == null)
          {
              return NotFound();
          }
            var systemAdministration = await _context.SystemAdministrations.FindAsync(id);

            if (systemAdministration == null)
            {
                return NotFound();
            }

            return systemAdministration;
        }

        // PUT: api/SystemAdministration/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSystemAdministration(int id, SystemAdministration systemAdministration)
        {
            if (id != systemAdministration.Id)
            {
                return BadRequest();
            }

            _context.Entry(systemAdministration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemAdministrationExists(id))
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

        // POST: api/SystemAdministration
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SystemAdministration>> PostSystemAdministration(SystemAdministration systemAdministration)
        {
          if (_context.SystemAdministrations == null)
          {
              return Problem("Entity set 'HomeServiceDBContext.SystemAdministrations'  is null.");
          }
            _context.SystemAdministrations.Add(systemAdministration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSystemAdministration", new { id = systemAdministration.Id }, systemAdministration);
        }

        // DELETE: api/SystemAdministration/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSystemAdministration(int id)
        {
            if (_context.SystemAdministrations == null)
            {
                return NotFound();
            }
            var systemAdministration = await _context.SystemAdministrations.FindAsync(id);
            if (systemAdministration == null)
            {
                return NotFound();
            }

            _context.SystemAdministrations.Remove(systemAdministration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SystemAdministrationExists(int id)
        {
            return (_context.SystemAdministrations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
