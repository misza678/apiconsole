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

      
        
    }
}
