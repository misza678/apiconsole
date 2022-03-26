using apiconsole.Models.CollectionCentre;
using consolestoreapi.Models;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace apiconsole.Handlers.CollectionItems
{
    public class PostCollectionItemHandler
    {
  
        public class Command : IRequest<CollectionItem>
        {
            public CollectionItem CollectionItem { get; set; }
        }
        public class PostCollectionItem : IRequestHandler<Command, CollectionItem>
        {
            private readonly ConsoleStoreDbContext _data;

            public PostCollectionItem(ConsoleStoreDbContext data)
            {
                _data = data;
            }
            public class CollectionItemValidator : AbstractValidator<CollectionItem>
            {
                public CollectionItemValidator()
                {
                    RuleFor(t => t.ModelID).NotEmpty().WithMessage("ModelID can't be empty").GreaterThanOrEqualTo(1).WithMessage("ModelID must be greather or equal 1");
                    RuleFor(t => t.WithController).NotEmpty().WithMessage("WithController can't be empty");
                    RuleFor(t => t.CustomerID).NotEmpty().WithMessage("CustomerID can't be empty").GreaterThanOrEqualTo(1).WithMessage("CustomerID must be greather or equal 1");
                    RuleFor(t => t.StatusID).NotEmpty().WithMessage("StatusID can't be empty").GreaterThanOrEqualTo(1).WithMessage("StatusID must be greather or equal 1");
                }

            }
            private bool CollectionItemExists(int id)
            {
                return _data.CollectionItem.Any(e => e.CollectionItemID == id);
            }
            public async Task<CollectionItem> Handle(Command request, CancellationToken cancellationToken)
            {

                var newCollectionItem = new CollectionItem
                {
                    CollectionItemID = request.CollectionItem.CollectionItemID,
                    ModelID = request.CollectionItem.ModelID,
                    CustomerID = request.CollectionItem.CustomerID,
                    WithController = request.CollectionItem.WithController,
                    StatusID = request.CollectionItem.StatusID
                };
                _data.CollectionItem.Add(newCollectionItem);


                try
                {
                    await _data.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollectionItemExists(newCollectionItem.CollectionItemID))
                    {
                        throw new KeyNotFoundException("CollectionItem has not been created");
                    }
                    else
                    {
                        throw;
                    }
                }
                return newCollectionItem;

            }
        }
    }
}


