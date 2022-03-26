
using apiconsole.Models.Repair;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace apiconsole.Handlers.Repairs
{
    public class GetRepairsByUserIDHandler
    {
    
        public class Command : IRequest<ICollection<Repair>>
        {
            public string UserID { get; set; }
        }
        public class GetCollectionItemsList : IRequestHandler<Command, ICollection<Repair>>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetCollectionItemsList(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<ICollection<Repair>> Handle(Command request, CancellationToken cancellationToken)
            {
                var userId = request.UserID;
                var confirmedRepair = await _data.Repair.Include(c => c.Customer).Where(c => c.Customer.UserID == userId).Include(c => c.Status).Include(c => c.Model).ToListAsync(cancellationToken);
                if (confirmedRepair == null)
                {
                    throw new KeyNotFoundException("Repairs not found");
                }
                return confirmedRepair;

            }
        }
    }
}

