using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.Repair;
using consolestoreapi.Models;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public ProductsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }


        // GET: api/Products/5
        [HttpGet("{CompanyName}")]
        public async Task<ActionResult<Product>> GetProduct(string CompanyName)
        {
            var product = await _context.Product.Include(c=>c.Company).Where(p=>p.Company.Name==CompanyName).ToListAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

    }
}
