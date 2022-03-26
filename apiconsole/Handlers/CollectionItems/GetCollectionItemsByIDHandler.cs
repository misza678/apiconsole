
using apiconsole.Models.CollectionCentre;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace apiconsole.Handlers.CollectionItems
{
    public class GetCollectionItemsByIDHandler
    {
        public class Command : IRequest<CollectionItem>
        {
            public int Id { get; set; }
        }
        public class GetCollectionItemsList : IRequestHandler<Command, CollectionItem>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetCollectionItemsList(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<CollectionItem> Handle(Command request, CancellationToken cancellationToken)
            {
                var itemId = request.Id;
              
                    var collectionItem = await _data.CollectionItem.FindAsync(itemId);
                    if (collectionItem == null)
                    {
                        throw new KeyNotFoundException("collectionItem not found");
                    }
                
            
             
                return collectionItem;



            }
        }
    }
}

