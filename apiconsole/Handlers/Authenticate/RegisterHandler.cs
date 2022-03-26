using MediatR;
using Microsoft.AspNetCore.Mvc;
using apiconsole.IdentityAuth;
using apiconsole.Models.Autorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace apiconsole.Handlers.Authenticate
{
    public class RegisterHandler
    {


        public class Command : IRequest<object>
        {
            public RegisterModel RegisterModel { get; set; }
        }
        public class Register : IRequestHandler<Command, object>
        {

            private readonly UserManager<ApplicationUser> _userManager;

            private readonly IConfiguration _configuration;




            public Register(UserManager<ApplicationUser> userManager, IConfiguration configuration)
            {
                _userManager = userManager;
                _configuration = configuration;
            }



            public async Task<object> Handle(Command request, CancellationToken cancellationToken)
            {

                var userExists = await _userManager.FindByIdAsync(request.RegisterModel.Username);
                if (userExists != null)
                {
                    throw new ApplicationException("User already exists");
                }
                   

                ApplicationUser user = new()
                {
                    Email = request.RegisterModel.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.RegisterModel.Username
                };

                var result = await _userManager.CreateAsync(user, request.RegisterModel.Password);
                if (!result.Succeeded)
                {
                    throw new ApplicationException(result.ToString());
                }
                   

                return new Response { Status = "Success", Message = "user created" };



            }
        }
    }
}