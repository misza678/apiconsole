using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiconsole.Models.Repair;
using consolestoreapi.Models;
using MediatR;
using apiconsole.Handlers.Products;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // GET: api/Products/5
        [HttpGet("{CompanyName}")]
        public async Task<List<Product>> GetProduct(string CompanyName)
        {
           return await _mediator.Send(new GetProductsListHandler.Command { CompanyName = CompanyName });
        }

    }
}
