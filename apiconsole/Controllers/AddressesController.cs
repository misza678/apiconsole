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
        private readonly ConsoleStoreDbContext _context;
        private readonly IMediator _mediator;
        public AddressesController(ConsoleStoreDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }


        // GET: api/Addresses

        [HttpGet]
        public async Task<ActionResult<Address>> GetAddress() 
        {
            if (User.Identity.Name == null)
            {
                return BadRequest("No User id");
            }
           return await _mediator.Send(new GetAddressList.Command { Id = User.Identity.Name });
            
        }
          

    
      
        [Authorize]
        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
            AddressValidator validator = new AddressValidator();

            ValidationResult results = validator.Validate(address);

            if (!results.IsValid)
            {

                foreach (var failure in results.Errors)
                {
                    BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }

            if (id != address.AddressID)
            {
                return BadRequest();
            }

            var newAddres = new Address
            {
                AddressID = address.AddressID,
                Street = address.Street,
                City = address.City,
                HouseNumber = address.HouseNumber,
                PostalAddress = address.PostalAddress,
                FlatNumber = address.FlatNumber
            };
            _context.Entry(newAddres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            AddressValidator validator = new AddressValidator();

            ValidationResult results = validator.Validate(address);

            if (!results.IsValid)
            {

                foreach (var failure in results.Errors)
                {
                    BadRequest("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
                }
            }
            var newAddres = new Address
            {
                AddressID = address.AddressID,
                Street = address.Street,
                City = address.City,
                HouseNumber = address.HouseNumber,
                PostalAddress = address.PostalAddress,
                FlatNumber = address.FlatNumber
            };


            _context.Address.Add(newAddres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = newAddres.AddressID }, newAddres);
        }

       

        private bool AddressExists(int id)
        {
            return _context.Address.Any(e => e.AddressID == id);
        }
    }
}
