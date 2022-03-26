using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.Other;
using consolestoreapi.Models;
using MediatR;
using apiconsole.Handlers.Statuses;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IMediator _mediator;
        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Status
        [HttpGet]
        public async Task<IEnumerable<Status>> GetStatus()
        {
            return await _mediator.Send(new GetStatusListHandler.Command());
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Status>> GetStatus(int id)
        {
            return await _mediator.Send(new GetStatusByIdHandler.Command { Id = id });
        }

 
    }
}
