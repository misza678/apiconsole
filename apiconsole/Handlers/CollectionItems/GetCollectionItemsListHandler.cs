using apiconsole.Models.CollectionCentre;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace apiconsole.Handlers.CollectionItems
{
    public class GetCollectionItemsListHandler
    {
        public class Command : IRequest<List<CollectionItem>>
        {
        }
        public class GetCollectionItemsList : IRequestHandler<Command, List<CollectionItem>>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetCollectionItemsList(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<List<CollectionItem>> Handle(Command request, CancellationToken cancellationToken)
            {

                var collectionlist= await _data.CollectionItem.Include(c => c.Customer).Include(c => c.Status).Include(c => c.Model).ToListAsync(cancellationToken);

              
                if (collectionlist == null) throw new KeyNotFoundException("CollectionList not found");
                
                return collectionlist;



            }
        }
    }
}

