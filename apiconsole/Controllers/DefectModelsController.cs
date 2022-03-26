using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.Repair;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using apiconsole.Handlers.Defects;
using System.Collections;

namespace apiconsole.Models.CollectionCentre
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefectModelsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DefectModelsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/DefectModels/5
        [HttpGet("{id}")]
        public async Task<ICollection> GetDefectModel(int id)
        {
            return await _mediator.Send(new GetDefectModelHandler.Command { Id = id });
           
        }

    }
}
