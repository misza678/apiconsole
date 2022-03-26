using consolestoreapi.Models;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;




namespace apiconsole.Handlers.Customers
{
    public class PostCustomerHandler
    {
        public class Command : IRequest<Customer>
        {
            public Customer Customer { get; set; }
            public string Id { get; set; }
        }

        public class PostCustomer : IRequestHandler<Command, Customer>
        {
            private readonly ConsoleStoreDbContext _data;

            public PostCustomer(ConsoleStoreDbContext data)
            {
                _data = data;
            }
            public class CustomerValidator : AbstractValidator<Customer>
            {
                public CustomerValidator()
                {
                    RuleFor(t => t.Name).NotEmpty().WithMessage("Name can't be empty").MaximumLength(20).WithMessage("Name max lenght is 20");
                    RuleFor(t => t.LastName).NotEmpty().WithMessage("LastName can't be empty").MaximumLength(50).WithMessage("LastName max lenght is 50");
                    RuleFor(t => t.Email).NotEmpty().WithMessage("Email can't be empty").MaximumLength(100).WithMessage("Email max lenght is 100");
                    RuleFor(t => t.Phone).NotEmpty().WithMessage("StatusID can't be empty").MaximumLength(12).WithMessage("Phone number max lenght is 12");
                    RuleFor(t => t.AddressID).NotEmpty().WithMessage("AddressID can't be empty").GreaterThanOrEqualTo(1).WithMessage("AddressID must be greather or equal 1");
                }

            }
            private bool CustomerExists(int id)
            {
                return _data.Customers.Any(e => e.CustomerID == id);
            }
            public async Task<Customer> Handle(Command request, CancellationToken cancellationToken)
            {

                var newCustomer = new Customer()
                {
                    CustomerID = request.Customer.CustomerID,
                    Name = request.Customer.Name,
                    LastName = request.Customer.LastName,
                    Email = request.Customer.Email,
                    UserID = request.Id,
                    Phone = request.Customer.Phone,
                    AddressID = request.Customer.AddressID,
                };

                _data.Customers.Add(newCustomer);

                try
                {
                    await _data.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(newCustomer.CustomerID))
                    {
                        throw new KeyNotFoundException("Customer has not been created");
                    }
                    else
                    {
                        throw;
                    }
                }
                return newCustomer;

            }
        }
    }
}