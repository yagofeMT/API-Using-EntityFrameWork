#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ControleFinanceiro.BLL.Models;
using ControleFinanceiro.DAL;

namespace ControleFinanceiro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private readonly Context _context;

        public TiposController(Context context)
        {
            _context = context;
        }

        // GET: api/Types
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tipo>>> GetTypes()
        {
            return await _context.Types.ToListAsync();
        }

        // GET: api/Types/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tipo>> GetType(int id)
        {
            var @type = await _context.Types.FindAsync(id);

            if (@type == null)
            {
                return NotFound();
            }

            return @type;
        }

        // PUT: api/Types/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType(int id, Tipo @type)
        {
            if (id != @type.Id)
            {
                return BadRequest();
            }

            _context.Entry(@type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
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

        // POST: api/Types
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tipo>> PostType(Tipo @type)
        {
            _context.Types.Add(@type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType", new { id = @type.Id }, @type);
        }

        // DELETE: api/Types/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var @type = await _context.Types.FindAsync(id);
            if (@type == null)
            {
                return NotFound();
            }

            _context.Types.Remove(@type);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeExists(int id)
        {
            return _context.Types.Any(e => e.Id == id);
        }
    }
}
