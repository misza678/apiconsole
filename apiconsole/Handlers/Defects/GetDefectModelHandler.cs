using apiconsole.Models.Repair;
using consolestoreapi.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace apiconsole.Handlers.Defects
{
    public class GetDefectModelHandler
    {
        public class Command : IRequest<ICollection>
        {
            public int Id { get; set; }
        }
        
        public class GetDefectModel : IRequestHandler<Command, ICollection>
        {
            private readonly ConsoleStoreDbContext _data;

            public GetDefectModel(ConsoleStoreDbContext data)
            {
                _data = data;
            }

            public async Task<ICollection> Handle(Command request, CancellationToken cancellationToken)
            {

                    var defectModel = await _data.DefectModel.Join(_data.Models.Where(a => a.ModelID == request.Id),
                     p => p.ModelID,
                     s => s.ModelID, (p, s) => new 
                     {
                         p.DefectID,
                         p.Defect.Name
                     }).ToListAsync();

             

                    if (defectModel == null)
                    {
                    throw new KeyNotFoundException("Defects not found");
                    }
                return (ICollection)defectModel;
            }
         }
        }
    }


