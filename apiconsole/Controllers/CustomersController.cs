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
    public class CustomersController : ControllerBase
    {
        private readonly ConsoleStoreDbContext _context;

        public CustomersController(ConsoleStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            if(id == 0)
            {
                var userId = this.User.Identity.Name;
                if (userId == null)
                {
                    return NotFound();
                }
            
                var customer2 = await _context.Address.Join(_context.Customers.Where(a => a.UserID == userId),
               p => p.AddressID,
               s => s.AddressID, (p, s) => new
               {
                   s.Name,
                   s.LastName,
                   s.Phone,
                   s.Email,
                   s.CustomerID,
                   p.AddressID,
                   p.Street,
                   p.City,
                   p.HouseNumber,
                   p.PostalAddress,
                   p.FlatNumber
               }).ToListAsync();


                if (customer2 == null)
                {
                    return NotFound();
                }

                return Ok(customer2);
            }
       
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
    

    // PUT: api/Customers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {

            var userId = this.User.Identity.Name;
            customer.UserID = userId;


            if (id != customer.CustomerID)
            {
                return BadRequest();
            }
          
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
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
        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            var userId = this.User.Identity.Name;
            customer.UserID = userId;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerID }, customer);
        }


        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerID == id);
        }
    }
}
