using consolestoreapi.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace apiconsole.Handlers.CollectionItems
{
    public class DeleteCollectionItemHandler
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteCollectionItem : IRequestHandler<Command, Unit>
        {
            private readonly ConsoleStoreDbContext _data;

            public DeleteCollectionItem(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
               
                var collectionItem = await _data.CollectionItem.FindAsync(request.Id);

                if (collectionItem == null)
                {
                    throw new KeyNotFoundException("collectionItem not found");
                }

                _data.CollectionItem.Remove(collectionItem);
                await _data.SaveChangesAsync();

                return Unit.Value;

            }
        }
    }
}
