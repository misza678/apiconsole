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
    public class DefectsController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public DefectsController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        

        // GET: api/Defects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Defect>>> GetDefect(int id)
        {
        
            if (id == 0)
            {
                return NotFound();
            }
            
            

            var defaultdefect= await _context.Defect.Where(x => x.DefectType == 1).ToListAsync();
            
            var defect = await _context.Defect.Where(x=>x.DefectType==id).ToListAsync();
            
            var mergedlist = defaultdefect.Union(defect).ToList();
          
            if (defect == null)
            {
                return NotFound();
            }

          
        
            return mergedlist;
        }
    }
}
