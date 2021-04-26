using System;
using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ISISNotesBackend.API.Controllers
{
    [Route("avatar")]
    public class AvatarController : Controller
    {
        private readonly IFacade _facade;
        private readonly IConfiguration _configuration;
        private string Path => _configuration["Database:StoredFilesPath"];

        public AvatarController(IFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }
        
        [Authorize]
        [Route("{userId}")]
        [HttpGet]
        public IActionResult GetAvatar(string userId)
        {
            try
            {
                return Ok(_facade.GetAvatar(userId, Path));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}