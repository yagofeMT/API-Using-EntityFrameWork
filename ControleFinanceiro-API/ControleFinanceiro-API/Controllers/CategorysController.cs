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
using Microsoft.AspNetCore.Cors;

namespace ControleFinanceiro_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorysController : ControllerBase
    {
        private readonly Context _context;

        public CategorysController(Context context)
        {
            _context = context;
        }

        // GET: api/Categorys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        {
            return await _context.Categories.Include(c => c.Type).ToListAsync();
        }

        // GET: api/Categorys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategorys(int id)
        {
            var categorys = await _context.Categories.FindAsync(id);

            if (categorys == null)
            {
                return NotFound();
            }

            return categorys;
        }

        // PUT: api/Categorys/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorys(int id, Category categorys)
        {
            if (id != categorys.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorys).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorysExists(id))
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

        // POST: api/Categorys
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategorys(Category categorys)
        {
            _context.Categories.Add(categorys);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorys", new { id = categorys.Id }, categorys);
        }

        // DELETE: api/Categorys/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorys(int id)
        {
            var categorys = await _context.Categories.FindAsync(id);
            if (categorys == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(categorys);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorysExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
