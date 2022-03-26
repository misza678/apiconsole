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
using apiconsole.Handlers.Customers;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // GET: api/Customers
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Customer>> GetCustomerById()
        {
            return await _mediator.Send(new GetCustomerByUserIdHandler.Command { Id = User.Identity.Name });
        }

        // GET: api/Customers/5
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return await _mediator.Send(new GetCustomerByIdHandler.Command { Id = id });
        }


        // PUT: api/Customers/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Customer>> PutCustomer(int id, Customer customer)
        {
            return await _mediator.Send(new PutCustomerHandler.Command { CustomerID = id, Customer = customer, Id = User.Identity.Name });        
        }


      
        // POST: api/Customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            return await _mediator.Send(new PostCustomerHandler.Command { Customer=customer , Id = User.Identity.Name});
        }
    }
}
