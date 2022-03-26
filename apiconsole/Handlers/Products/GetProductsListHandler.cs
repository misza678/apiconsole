
using apiconsole.Models.Repair;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Products
{
    public class GetProductsListHandler
    {
        public class Command : IRequest<List<Product>>
        {
            public string CompanyName { get; set; }
        }
        public class GetProductsList : IRequestHandler<Command, List<Product>>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetProductsList(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<List<Product>> Handle(Command request, CancellationToken cancellationToken)
            {

                var productList = await _data.Product.Include(c => c.Company).Where(p => p.Company.Name == request.CompanyName).ToListAsync();
                if (productList == null)
                {
                    throw new KeyNotFoundException("Models not found");
                }
                return productList;



            }
        }
    }
}
