using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ISISNotesBackend.API.Controllers
{
    [Route("session")]
    public class SessionController : Controller
    {
        private readonly IOptions<JwtAuthentication> _authOptions;
        private readonly IFacade _facade;
        private readonly IConfiguration _configuration;

        public SessionController(IOptions<JwtAuthentication> authOptions, IFacade facade, IConfiguration configuration)
        {
            _authOptions = authOptions;
            _facade = facade;
            _configuration = configuration;  
        }
        
        [Route("")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] Login request)
        {
            var user = _facade.EnterUser(request.Username, request.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = GenerateJwt(user);
            return Ok(new Session(Guid.NewGuid().ToString(), token, user, DateTime.Now));
        }

        [Route("{id}")]
        [Authorize]
        [HttpDelete]
        public IActionResult Logout(string id)
        {
            var session = _facade.DeleteSession(id);

            if (session == null)
            {
                return Unauthorized();
            }
            
            return Ok(session);
        }

        private string GenerateJwt(User user)
        {
            var authParams = _authOptions.Value;

            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Email, user.Email)
            };

            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifeTime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}