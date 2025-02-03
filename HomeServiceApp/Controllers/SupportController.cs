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
    public class SupportController : ControllerBase
    {
        private readonly HomeServiceDBContext _context;

        public SupportController(HomeServiceDBContext context)
        {
            _context = context;
        }

        // GET: api/Support
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Support>>> GetSupports()
        {
          if (_context.Supports == null)
          {
              return NotFound();
          }
            return await _context.Supports.ToListAsync();
        }

        // GET: api/Support/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Support>> GetSupport(int id)
        {
          if (_context.Supports == null)
          {
              return NotFound();
          }
            var support = await _context.Supports.FindAsync(id);

            if (support == null)
            {
                return NotFound();
            }

            return support;
        }

        // PUT: api/Support/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupport(int id, Support support)
        {
            if (id != support.Id)
            {
                return BadRequest();
            }

            _context.Entry(support).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupportExists(id))
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

        // POST: api/Support
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Support>> PostSupport(Support support)
        {
          if (_context.Supports == null)
          {
              return Problem("Entity set 'HomeServiceDBContext.Supports'  is null.");
          }
            _context.Supports.Add(support);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupport", new { id = support.Id }, support);
        }

        // DELETE: api/Support/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupport(int id)
        {
            if (_context.Supports == null)
            {
                return NotFound();
            }
            var support = await _context.Supports.FindAsync(id);
            if (support == null)
            {
                return NotFound();
            }

            _context.Supports.Remove(support);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupportExists(int id)
        {
            return (_context.Supports?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
