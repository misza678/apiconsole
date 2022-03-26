using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Customers
{
    public class GetCustomerByUserIdHandler
    { 
         public class Command : IRequest<Customer>
    {
        public string Id { get; set; }
    }

    public class GetCustomerByUserId : IRequestHandler<Command, Customer>
    {
        private readonly ConsoleStoreDbContext _data;

        public GetCustomerByUserId(ConsoleStoreDbContext data)
        {
            _data = data;
        }

        public async Task<Customer> Handle(Command request, CancellationToken cancellationToken)
        {

                var customer = await _data.Customers.Where(a => a.UserID == request.Id).Include(c => c.Address).FirstOrDefaultAsync();
              
                if (customer == null)
                {
                    throw new KeyNotFoundException("Customer not found");
                }

                return customer;

        }
    }
    }
}
