using apiconsole.Models.Other;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;



namespace apiconsole.Handlers.Companies
{
    public class GetCompaniesListHandler
    {


        public class Command : IRequest<List<Company>>
        {
        }
        public class GetCompaniesList : IRequestHandler<Command, List<Company>>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetCompaniesList(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<List<Company>> Handle(Command request, CancellationToken cancellationToken)
            {

                var companiesList = await _data.Company.ToListAsync();


                if (companiesList == null) throw new KeyNotFoundException("CompaniesList not found");

                return companiesList;



            }
        }
    }
}


