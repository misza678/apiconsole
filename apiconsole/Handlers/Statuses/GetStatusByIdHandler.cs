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
    public class GetStatusByIdHandler
    {
        public class Command : IRequest<Status>
        {
            public int Id { get; set; }
        }
        public class GetStatusById : IRequestHandler<Command, Status>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetStatusById(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<Status> Handle(Command request, CancellationToken cancellationToken)
            {

                var productList = await _data.Status.FindAsync(request.Id);
                if (productList == null)
                {
                    throw new KeyNotFoundException("Status not found");
                }
                return productList;

            }
        }
    }
}
