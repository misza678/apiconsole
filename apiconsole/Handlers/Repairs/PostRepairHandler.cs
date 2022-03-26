using apiconsole.Models.Repair;
using consolestoreapi.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Repairs
{
    public class PostRepairHandler
    {
 
        public class Command : IRequest<Repair>
        {
            public Repair Repair { get; set; }
        }
        public class PostCollectionItem : IRequestHandler<Command, Repair>
        {
            private readonly ConsoleStoreDbContext _data;

            public PostCollectionItem(ConsoleStoreDbContext data)
            {
                _data = data;
            }
            public class RepairValidator : AbstractValidator<Repair>
            {
                public RepairValidator()
                {
                    RuleFor(t => t.ModelID).NotEmpty().WithMessage("ModelID can't be empty").GreaterThanOrEqualTo(1).WithMessage("ModelID must be greather or equal 1");
                    RuleFor(t => t.ShippingMetodID).NotEmpty().WithMessage("ShippingMetodID can't be empty").GreaterThanOrEqualTo(1).WithMessage("ShippingMetodID must be greather or equal 1");
                    RuleFor(t => t.CustomerID).NotEmpty().WithMessage("CustomerID can't be empty").GreaterThanOrEqualTo(1).WithMessage("CustomerID must be greather or equal 1");
                    RuleFor(t => t.DefectID).NotEmpty().WithMessage("DefectID can't be empty").GreaterThanOrEqualTo(1).WithMessage("DefectID must be greather or equal 1");
                    RuleFor(t => t.StatusID).NotEmpty().WithMessage("StatusID can't be empty").GreaterThanOrEqualTo(1).WithMessage("StatusID must be greather or equal 1");
                }

            }
            private bool RepairExists(int id)
            {
                return _data.Repair.Any(e => e.RepairID == id);
            }
            public async Task<Repair> Handle(Command request, CancellationToken cancellationToken)
            {

                var newRepair = new Repair
                {
                    RepairID = request.Repair.RepairID,
                    CustomerID = request.Repair.CustomerID,
                    StatusID = request.Repair.StatusID,
                    ShippingMetodID = request.Repair.ShippingMetodID,
                    ModelID = request.Repair.ModelID,
                    DefectID = request.Repair.DefectID,
                    Description = request.Repair.Description,
                    Price = request.Repair.Price
                };
                _data.Repair.Add(newRepair);


                try
                {
                    await _data.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairExists(newRepair.RepairID))
                    {
                        throw new KeyNotFoundException("Repair has not been created");
                    }
                    else
                    {
                        throw;
                    }
                }
                return newRepair;

            }
        }
    }
}


