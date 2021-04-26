using System;
using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ISISNotesBackend.API.Controllers
{
    [Route("users")]
    public class UserController : Controller
    {
        private readonly IFacade _facade;
        private readonly IConfiguration _configuration;
        private string Path => _configuration["Database:StoredFilesPath"];
        
        public UserController(IFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }
        
        [Route("")]
        [HttpGet]
        public User[] GetUsers()
        {
            return _facade.GetAllUsers();
        }
        
        [Route("")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserWithLogin userWithLogin)
        {
            try
            {
                return Ok(_facade.CreateUser(userWithLogin));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
        }
        
        [Route("")]
        [HttpPatch]
        public IActionResult ChangeUser([FromBody]  UserWithLoginAndAvatar userWithLoginAndAvatar)
        {
            try
            {
                return Ok(_facade.ChangeUser(userWithLoginAndAvatar, Path));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return NotFound();
            }
        }
    }
}