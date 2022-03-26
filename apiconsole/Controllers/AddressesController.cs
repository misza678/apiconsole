using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;
using MediatR;
using apiconsole.Handlers;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AddressesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Addresses
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Address>> GetAddress() 
        {
            return await _mediator.Send(new GetAddressHandler.Command { Id = User.Identity.Name });

        }
          
        [Authorize]
        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<Address> PutAddress(int id, Address address)
        {
            return await _mediator.Send(new PutAddressHandler.Command { Id = id, Address = address});
           
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            return await _mediator.Send(new PostAddressHandler.Command { Address= address });
        
        }
    }
}
