using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace apiconsole.Handlers
{
    public class GetAddressList
    {

        public class Command : IRequest<Address>
        {
            public string Id { get; set; }
        }
        public class GetAddressHandler : IRequestHandler<Command, Address>
        { 
        private readonly ConsoleStoreDbContext _data;

        public GetAddressHandler(ConsoleStoreDbContext data)
        {
            _data = data;
        }

        public async Task<Address> Handle(Command request, CancellationToken cancellationToken)
        {
          
            var Id=request.Id;

            var customer= await _data.Customers.Where(c=>c.UserID==Id).FirstOrDefaultAsync();

            var address = await _data.Address.Where(c => c.AddressID == customer.AddressID).FirstOrDefaultAsync();


            return address;


        }
    }}
}
