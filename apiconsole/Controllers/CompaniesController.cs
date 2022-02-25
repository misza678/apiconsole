using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Authorization;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public CompaniesController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Company>>> GetCompany()
        {
            return await _context.Company.ToListAsync();
        }

       
    }
}
