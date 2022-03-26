using apiconsole.Handlers.Authenticate;
using apiconsole.IdentityAuth;
using apiconsole.Models.Autorization;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace apiconsole.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("register")]
        public async Task<object> Register([FromBody] RegisterModel model)
        {
            return await _mediator.Send(new RegisterHandler.Command { RegisterModel = model });
        }



        [HttpPost]
        [Route("login")]
        public async Task<object> Login([FromBody] LoginModel model)
        {
            return await _mediator.Send(new LoginHandler.Command { LoginModel = model });
        }
    }
}

