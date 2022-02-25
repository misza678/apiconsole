using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models;
using consolestoreapi.Models;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public ModelsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Models
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> GetModel()
        {
            return await _context.Models.ToListAsync();
        }

        // GET: api/Models/5
        [HttpGet("{id}/{Category}")]
        public async Task<ActionResult<Model>> GetModel(int id,string Category)
        {
            var model = await _context.Models.Where(c=>c.ProductID==id).Include(c=>c.Category).Where(c=>c.Category.Name==Category).ToListAsync();

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        // PUT: api/Models/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModel(int id, Model model)
        {
            if (id != model.ModelID)
            {
                return BadRequest();
            }

            _context.Entry(model).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelExists(id))
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

        // POST: api/Models
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Model>> PostModel(Model model)
        {
            _context.Models.Add(model);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModel", new { id = model.ModelID }, model);
        }

        // DELETE: api/Models/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var model = await _context.Models.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }

            _context.Models.Remove(model);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelExists(int id)
        {
            return _context.Models.Any(e => e.ModelID == id);
        }
    }
}
