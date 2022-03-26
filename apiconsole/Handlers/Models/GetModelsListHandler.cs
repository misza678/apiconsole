
using apiconsole.Models;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Models
{
    public class GetModelsListHandler
    {
    
        public class Command : IRequest<List<Model>>
        {
            public int ProductID { get; set; }
            public string CategoryName { get; set; }
        }
        public class GetModelsList : IRequestHandler<Command, List<Model>>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetModelsList(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<List<Model>> Handle(Command request, CancellationToken cancellationToken)
            {

                var modelList = await _data.Models.Where(c => c.ProductID == request.ProductID).Include(c => c.Category).Where(c => c.Category.Name == request.CategoryName).ToListAsync(cancellationToken);

                if (modelList == null) 
                {
                    throw new KeyNotFoundException("Models not found");
                }
                return modelList;



            }
        }
    }
}


