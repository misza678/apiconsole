using apiconsole.Models.Repair;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Repairs
{
    public class DeleteRepairHandler
    {
       
    
        public class Command : IRequest
        {
            public int RepairId { get; set; }
        }
        public class DeleteRepair : IRequestHandler<Command, Unit>
        {
            private readonly ConsoleStoreDbContext _data;

            public DeleteRepair(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var repair = await _data.Repair.FindAsync(request.RepairId);
                if (repair == null)
                {
                    throw new KeyNotFoundException("Repair not found");
                }

                _data.Repair.Remove(repair);

                await _data.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
