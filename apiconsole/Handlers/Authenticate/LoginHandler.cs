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

namespace apiconsole.Handlers.Authenticate
{
    public class LoginHandler
    {


        public class Command : IRequest<object>
        {
            public LoginModel LoginModel { get; set; }
        }
        public class Login : IRequestHandler<Command, object>
        {

            private readonly UserManager<ApplicationUser> _userManager;

            private readonly IConfiguration _configuration;




            public Login(UserManager<ApplicationUser> userManager, IConfiguration configuration)
            {
                _userManager = userManager;
                _configuration = configuration;
            }


            public async Task<object> Handle(Command request, CancellationToken cancellationToken)
            {

                var user = await _userManager.FindByNameAsync(request.LoginModel.Username);
                if (user != null && await _userManager.CheckPasswordAsync(user, request.LoginModel.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                    foreach (var userRole in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                    }
                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));


                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                    return new { token = new JwtSecurityTokenHandler().WriteToken(token), expiration = token.ValidTo };

                }
                throw new UnauthorizedAccessException();


            }
        }
    }
}