using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;
using MediatR;
using apiconsole.Handlers.Repairs;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepairsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RepairsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Repairs
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpGet]
        public async Task<ICollection<Repair>> GetRepair()
        {
            return await _mediator.Send(new GetRepairListHandler.Command());
        }

        [Authorize]
        [HttpGet]
        [Route("api/ByUserId")]
        public async Task<ICollection<Repair>> GetRepairByUserId()
        {
            return await _mediator.Send(new GetRepairsByUserIDHandler.Command { UserID = User.Identity.Name });  
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<Repair> GetRepair(int id)
        {
            return await _mediator.Send(new GetRepairByIDHandler.Command { ID = id });
           
            }

        // PUT: api/Repairs/5
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Repair>> PutRepair(int id, Repair repair)
        {
            return await _mediator.Send(new PutRepairHandler.Command { Id = id, Repair = repair });
            
        }


        // POST: api/Repairs
        [HttpPost]
        public async Task<ActionResult<Repair>> PostRepair(Repair repair)
        {
            return await _mediator.Send(new PostRepairHandler.Command { Repair=repair });
             
        } 

        // DELETE: api/Repairs/5
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpDelete("{id}")]
        public async Task<Unit> DeleteRepair(int id)
        {
            return await _mediator.Send(new DeleteRepairHandler.Command { RepairId = id });
        }

      
    }
}
