using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.CollectionCentre;
using consolestoreapi.Models;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.Results;
using MediatR;
using apiconsole.Handlers.CollectionItems;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CollectionItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // GET: api/CollectionItems
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionItem>>> GetCollectionItem()
        {
            return await _mediator.Send(new GetCollectionItemsListHandler.Command());
        }


        // GET: api/CollectionItems/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<CollectionItem>> GetCollectionItem(int id)
        {

            return await _mediator.Send(new GetCollectionItemsByIDHandler.Command { Id = id });

        }

        [Authorize]
        [HttpGet]
        [Route("api/ByUserId")]
        public async Task<ICollection<CollectionItem>> GetCollectionItemUserId()
        {
            return await _mediator.Send(new GetCollectionItemByUserHandler.Command { UserID = User.Identity.Name });
        }
        // PUT: api/CollectionItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpPut("{id}")]
        public async Task<ActionResult<CollectionItem>> PutCollectionItem(int id, CollectionItem collectionItem)
        {

         return await _mediator.Send(new PutCollectionItemHandler.Command { Id = id, CollectionItem = collectionItem });

        }


        // POST: api/CollectionItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CollectionItem>> PostCollectionItem(CollectionItem collectionItem)
        {
            return await _mediator.Send(new  PostCollectionItemHandler.Command { CollectionItem = collectionItem });
        }


        // DELETE: api/CollectionItems/5
        [Authorize(Roles = "Pracownik,Administrator")]
        [HttpDelete("{id}")]
        public async Task<Unit> DeleteCollectionItem(int id)
        {
           return await _mediator.Send(new DeleteCollectionItemHandler.Command { Id = id});
        }


    }
}

