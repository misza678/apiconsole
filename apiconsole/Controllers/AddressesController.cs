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
    public class AddressesController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public AddressesController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Addresses
        [HttpGet]
        public async Task<ActionResult<Address>> GetAddress()
        {
            var userId = this.User.Identity.Name;
            var address = await _context.Address.Join(_context.Customers.Where(a=>a.UserID==userId),
                p => p.AddressID,
                s => s.AddressID, (p, s) => new
                {
                    p.AddressID,
                    p.Street,
                    p.City,
                    p.HouseNumber,
                    p.PostalAddress,
                    p.FlatNumber
                }).ToListAsync();



            if (address == null)
            {
                return NotFound();
            }

            return Ok(address);
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address address)
        {
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
        [Authorize(Roles = "Pracownik,Administrator,Użytkownik")]
        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
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
