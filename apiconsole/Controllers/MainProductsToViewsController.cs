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
    public class MainProductsToViewsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public MainProductsToViewsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

       
        // GET: api/MainProductsToViews/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<MainProductsToView>>> GetMainProductsToView(string id)
        {
            int idsearch=0;
            if (id == "playstation")
            {
                idsearch = 1;
            }
            else
            { idsearch = 2; }
                



            var mainProductsToView = await _context.MainProductToView.Where(x=>x.CompanyId== idsearch).ToListAsync();

            if (mainProductsToView == null)
            {
                return NotFound();
            }

            return mainProductsToView;
        }

     
    }
}
