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
    public class GetCollectionItemByUserHandler
    {
   

        public class Command : IRequest<ICollection<CollectionItem>>
        {
            public string UserID { get; set; }
        }
        public class GetCollectionItemByUser : IRequestHandler<Command, ICollection<CollectionItem>>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetCollectionItemByUser(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<ICollection<CollectionItem>> Handle(Command request, CancellationToken cancellationToken)
            {
                var userId = request.UserID;
                var confirmedRepair = await _data.CollectionItem.Include(c => c.Customer).Where(c => c.Customer.UserID == userId).Include(c => c.Status).Include(c => c.Model).ToListAsync(cancellationToken);
                if (confirmedRepair == null)
                {
                    throw new KeyNotFoundException("CollectionItem not found");
                }
                return confirmedRepair;

            }
        }
    }
}

