using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models;
using consolestoreapi.Models;
using MediatR;
using apiconsole.Handlers;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingMetodsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ShippingMetodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/ShippingMetods
        [HttpGet]
        public async Task<IEnumerable<ShippingMetod>> GetShippingMetod()
        {
            return await _mediator.Send(new GetShippingMetodsHandler.Command());
        }

       
    }
}
