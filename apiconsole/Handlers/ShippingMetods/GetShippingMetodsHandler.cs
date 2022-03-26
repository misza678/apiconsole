using apiconsole.Models;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace apiconsole.Handlers
{
    public class GetShippingMetodsHandler
    {

        public class Command : IRequest<IEnumerable<ShippingMetod>>
        {
        }
        public class GetShippingMetods : IRequestHandler<Command, IEnumerable<ShippingMetod>>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetShippingMetods(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<IEnumerable<ShippingMetod>> Handle(Command request, CancellationToken cancellationToken)
            {
                
                var ShippingMetodList = await _data.ShippingMetod.ToListAsync(cancellationToken);
                if (ShippingMetodList == null)
                {
                    throw new KeyNotFoundException("ShippingMetods not found");
                }
                return ShippingMetodList;



            }
        }
    }
}
