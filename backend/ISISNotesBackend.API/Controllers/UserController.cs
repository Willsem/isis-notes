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
        public User[] GetUsers()
        {
            return _facade.GetAllUsers();
        }
        
        [Route("")]
        public User CreateUser([FromBody] UserWithLogin userWithLogin)
        {
            return _facade.CreateUser(userWithLogin);
        }
        
        [Route("")]
        public User ChangeUser([FromBody]  UserWithLoginAndAvatar userWithLoginAndAvatar)
        {
            return _facade.ChangeUser(userWithLoginAndAvatar, Path);
        }
    }
}