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
    public class ShippingMetodsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public ShippingMetodsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/ShippingMetods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShippingMetod>>> GetShippingMetod()
        {
            return await _context.ShippingMetod.ToListAsync();
        }

       
    }
}
