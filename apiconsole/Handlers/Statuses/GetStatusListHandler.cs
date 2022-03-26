using apiconsole.Models.Other;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Statuses
{
    public class GetStatusListHandler
    {

        public class Command : IRequest<IEnumerable<Status>>
        {
        }
        public class GetStatusList : IRequestHandler<Command, IEnumerable<Status>>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetStatusList(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<IEnumerable<Status>> Handle(Command request, CancellationToken cancellationToken)
            {

                var productList = await _data.Status.ToListAsync(cancellationToken);
                if (productList == null)
                {
                    throw new KeyNotFoundException("Status not found");
                }
                return productList;



            }
        }
    }
}
