using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.CollectionCentre;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionItemsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public CollectionItemsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/CollectionItems
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionItem>>> GetCollectionItem()
        {
            return  await _context.CollectionItem.Include(c => c.Customer).Include(c => c.Status).Include(c => c.Model).ToListAsync();
        }


        // GET: api/CollectionItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionItem>> GetCollectionItem(int id)
        {
       

            var userId = this.User.Identity.Name;
            var confirmedRepair = await _context.CollectionItem.Include(c => c.Customer).Where(c => c.Customer.UserID == userId).Include(c => c.Status).Include(c => c.Model).ToListAsync();
            if (confirmedRepair == null)
            {
                return NotFound();
            }



            return Ok(confirmedRepair);
        }

        // PUT: api/CollectionItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollectionItem(int id, CollectionItem collectionItem)
        {
            CollectionItemValidator validator = new CollectionItemValidator();

            ValidationResult results = validator.Validate(collectionItem);

            if (!results.IsValid)
            {

                foreach (var failure in results.Errors)
                {
                    BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            if (id != collectionItem.CollectionItemID)
            {
                return BadRequest();
            }

            var newCollectionItem = new CollectionItem
            {
                CollectionItemID = collectionItem.CollectionItemID,
                ModelID = collectionItem.ModelID,
                CustomerID = collectionItem.CustomerID,
                WithController = collectionItem.WithController,
                StatusID = collectionItem.StatusID
            };

            _context.Entry(newCollectionItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CollectionItemExists(id))
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

        
        // POST: api/CollectionItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollectionItem>> PostCollectionItem(CollectionItem collectionItem)
        {
            CollectionItemValidator validator = new CollectionItemValidator();

            ValidationResult results = validator.Validate(collectionItem);

            if (!results.IsValid)
            {

                foreach (var failure in results.Errors)
                {
                    BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            var newCollectionItem = new CollectionItem
            {
                CollectionItemID = collectionItem.CollectionItemID,
                ModelID = collectionItem.ModelID,
                CustomerID = collectionItem.CustomerID,
                WithController = collectionItem.WithController,
                StatusID = collectionItem.StatusID
            };
            _context.CollectionItem.Add(newCollectionItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCollectionItem", new { id = newCollectionItem.CollectionItemID }, newCollectionItem);
        }


        // DELETE: api/CollectionItems/5
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCollectionItem(int id)
        {
            var collectionItem = await _context.CollectionItem.FindAsync(id);
            if (collectionItem == null)
            {
                return NotFound();
            }

            _context.CollectionItem.Remove(collectionItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CollectionItemExists(int id)
        {
            return _context.CollectionItem.Any(e => e.CollectionItemID == id);
        }
    }
}
