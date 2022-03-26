using consolestoreapi.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Customers
{
    public class GetCustomerByIdHandler
    {
        public class Command : IRequest<Customer>
        {
            public int Id { get; set; }
        }
        public class GetCustomerById : IRequestHandler<Command, Customer>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetCustomerById(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<Customer> Handle(Command request, CancellationToken cancellationToken)
            {

                var customer = await _data.Customers.FindAsync(request.Id);

                if (customer == null)
                {
                    throw new KeyNotFoundException("Customer not found");
                }

                return customer;
            }
        }
    }
}

          