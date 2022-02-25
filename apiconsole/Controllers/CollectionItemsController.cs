using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.CollectionCentre;
using consolestoreapi.Models;

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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionItem>>> GetCollectionItem()
        {
            return await _context.CollectionItem.ToListAsync();
        }

        // GET: api/CollectionItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionItem>> GetCollectionItem(int id)
        {
            var collectionItem = await _context.CollectionItem.FindAsync(id);

            if (collectionItem == null)
            {
                return NotFound();
            }

            return collectionItem;
        }

        // PUT: api/CollectionItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCollectionItem(int id, CollectionItem collectionItem)
        {
            if (id != collectionItem.CollectionItemID)
            {
                return BadRequest();
            }

            _context.Entry(collectionItem).State = EntityState.Modified;

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
            _context.CollectionItem.Add(collectionItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCollectionItem", new { id = collectionItem.CollectionItemID }, collectionItem);
        }

        // DELETE: api/CollectionItems/5
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
