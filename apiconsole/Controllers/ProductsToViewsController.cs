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
    public class ProductsToViewsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;
        public ProductsToViewsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ProductsToView>>> GetProductsToView(int id,int category)
        {

            var ProductsToView = await _context.ProductsToView.Where(x => x.MainProductsToViewId == id&x.CategoryId==category).ToListAsync();

            if (ProductsToView == null)
            {
                return NotFound();
            }

            return ProductsToView;
        }

    }
}
