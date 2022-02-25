using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.Repair;
using consolestoreapi.Models;

namespace apiconsole.Models.CollectionCentre
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefectModelsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public DefectModelsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/DefectModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DefectModel>>> GetDefectModel()
        {
            return await _context.DefectModel.ToListAsync();
        }

        // GET: api/DefectModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DefectModel>> GetDefectModel(int id)
        {
          
            var defectModel = await _context.DefectModel.Join(_context.Models.Where(a => a.ModelID == id),
               p => p.ModelID,
               s => s.ModelID, (p, s) => new
               {
                   p.DefectID,
                   p.Defect.Name
               }).ToListAsync();
            if (defectModel == null)
            {
                return NotFound();
            }

            return Ok(defectModel);
        }

        // PUT: api/DefectModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDefectModel(int id, DefectModel defectModel)
        {
            if (id != defectModel.ModelID)
            {
                return BadRequest();
            }

            _context.Entry(defectModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DefectModelExists(id))
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

        // POST: api/DefectModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DefectModel>> PostDefectModel(DefectModel defectModel)
        {
            _context.DefectModel.Add(defectModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DefectModelExists(defectModel.ModelID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDefectModel", new { id = defectModel.ModelID }, defectModel);
        }

        // DELETE: api/DefectModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDefectModel(int id)
        {
            var defectModel = await _context.DefectModel.FindAsync(id);
            if (defectModel == null)
            {
                return NotFound();
            }

            _context.DefectModel.Remove(defectModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DefectModelExists(int id)
        {
            return _context.DefectModel.Any(e => e.ModelID == id);
        }
    }
}
