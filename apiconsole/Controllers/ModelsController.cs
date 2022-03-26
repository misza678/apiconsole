
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models;
using consolestoreapi.Models;
using apiconsole.Handlers.Models;
using MediatR;
using System.Collections.Generic;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Models/5
        [HttpGet("{id}/{Category}")]
        public async Task<List<Model>> GetModel(int id,string Category)
        {
            return await _mediator.Send(new GetModelsListHandler.Command { ProductID = id, CategoryName = Category });
        }

      
        
    }
}
