
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
    public class GetRepairByIDHandler
    {

        public class Command : IRequest<Repair>
        {
            public int ID { get; set; }
        }
        public class GetCollectionItemsList : IRequestHandler<Command, Repair>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetCollectionItemsList(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<Repair> Handle(Command request, CancellationToken cancellationToken)
            {
                var repair = await _data.Repair.FindAsync(request.ID);

                if (repair == null)
                {
                    throw new KeyNotFoundException("Repairs not found");

                }

                return repair;

            }
        }
    }
}

