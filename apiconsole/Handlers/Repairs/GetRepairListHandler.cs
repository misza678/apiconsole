using apiconsole.Models.Repair;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Repairs
{
    public class GetRepairListHandler
    {
   
        public class Command : IRequest<ICollection<Repair>>
        {
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

                var repairlist= await _data.Repair.Include(c => c.Customer).Include(c => c.Status).Include(c => c.Model).ToListAsync(cancellationToken);

                if (repairlist == null) throw new KeyNotFoundException("RepairList not found");

                return repairlist;

            }
        }
    }
}

