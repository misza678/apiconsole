using consolestoreapi.Models;
using FluentValidation;
using FluentValidation.Results;
using Legacy.Platform.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace apiconsole.Handlers
    {
        public class PutAddressHandler
        {

            public class Command : IRequest<Address>
            {
                public Address Address { get; set; }
                public int Id { get; set; }
            }
            public class PutAddress : IRequestHandler<Command, Address>
            {
                private readonly ConsoleStoreDbContext _data;

                public PutAddress(ConsoleStoreDbContext data)
                {
                    _data = data;
                }
                public class AddressValidator : AbstractValidator<Address>
                {
                    public AddressValidator()
                    {
                        RuleFor(t => t.City).NotEmpty().WithMessage("City can't be empty").MaximumLength(45).WithMessage("City max lenght is 45");
                        RuleFor(t => t.PostalAddress).NotEmpty().WithMessage("PostalAddress can't be empty").MaximumLength(6).WithMessage("PostalAddress max lenght is 6");
                        RuleFor(t => t.Street).NotEmpty().WithMessage("Street can't be empty").MaximumLength(45).WithMessage("Street max lenght is 45");
                        RuleFor(t => t.HouseNumber).NotEmpty().WithMessage("HouseNumber can't be empty").MaximumLength(5).WithMessage("HouseNumber max lenght is 5");
                        RuleFor(t => t.FlatNumber).NotEmpty().WithMessage("FlatNumber can't be empty").GreaterThanOrEqualTo(1).WithMessage("FlatNumber must be greather or equal 1");
                    }

                }
            private bool AddressExists(int id)
            {
                return _data.Address.Any(e => e.AddressID == id);
            }
            public async Task<Address> Handle(Command request, CancellationToken cancellationToken)
                {
        
                if (request.Id != request.Address.AddressID)
                {
                    throw new ApplicationException("Bad address request");
                }

                var newAddres = new Address
                {
                    AddressID = request.Address.AddressID,
                    Street = request.Address.Street,
                    City = request.Address.City,
                    HouseNumber = request.Address.HouseNumber,
                    PostalAddress = request.Address.PostalAddress,
                    FlatNumber = request.Address.FlatNumber
                };

                _data.Entry(newAddres).State = EntityState.Modified;

                try
                {
                    await _data.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(request.Id))
                    {
                        throw new KeyNotFoundException("Address does not exist");
                    }
                    else
                    {
                        throw;
                    }
                }
                return newAddres;


            }
            }
        }
    }





