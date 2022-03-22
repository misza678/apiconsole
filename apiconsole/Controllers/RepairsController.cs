using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public RepairsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Repairs
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Repair>>> GetRepair()
        {
            return await _context.Repair.Include(c => c.Customer).Include(c => c.Status).Include(c => c.Model).ToListAsync();
        }
        [Authorize]
        // GET: api/Repairs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Repair>> GetRepair(int id)
        {
            
            var userId = this.User.Identity.Name;
            if (userId == null)
            {
                var repair = await _context.Repair.FindAsync(id);
                if (repair == null)
                {
                    return NotFound();
                }
              
                return repair;
            }
            var confirmedRepair = await _context.Repair.Include(c => c.Customer).Where(c => c.Customer.UserID == userId).Include(c=>c.Status).Include(c=>c.Model).ToListAsync();
            if (confirmedRepair == null)
            {
                return NotFound();
            }

            return Ok(confirmedRepair);
        }

        // PUT: api/Repairs/5
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepair(int id, Repair repair)
        {
            RepairValidator validator = new RepairValidator();

            ValidationResult results = validator.Validate(repair);

            if (!results.IsValid)
            {

                foreach (var failure in results.Errors)
                {
                    BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            } 

            if (id != repair.RepairID)
            {
                return BadRequest();
            }

            var newRepair = new Repair
            {
                RepairID = repair.RepairID,
                CustomerID = repair.CustomerID,
                StatusID = repair.StatusID,
                ShippingMetodID = repair.ShippingMetodID,
                ModelID = repair.ModelID,
                DefectID = repair.DefectID,
                Description = repair.Description,
                Price = repair.Price,
            };
            _context.Entry(newRepair).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepairExists(id))
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


        // POST: api/Repairs
        [HttpPost]
        public async Task<ActionResult<Repair>> PostRepair(Repair repair)
        {
            RepairValidator validator = new RepairValidator();

            ValidationResult results = validator.Validate(repair);

            if (!results.IsValid)
            {
             
                foreach (var failure in results.Errors)
                {
                    BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

                var newRepair = new Repair {
                RepairID = repair.RepairID,
                CustomerID = repair.CustomerID,
                StatusID = repair.StatusID,
                ShippingMetodID = repair.ShippingMetodID,
                ModelID = repair.ModelID,
                DefectID = repair.DefectID,
                Description = repair.Description,
                Price = repair.Price       
            };
            _context.Repair.Add(newRepair);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepair", new { id = newRepair.RepairID }, newRepair);
        } 

        // DELETE: api/Repairs/5
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRepair(int id)
        {
            var repair = await _context.Repair.FindAsync(id);
            if (repair == null)
            {
                return NotFound();
            }
            _context.Repair.Remove(repair);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RepairExists(int id)
        {
            return _context.Repair.Any(e => e.RepairID == id);
        }
    }
}
