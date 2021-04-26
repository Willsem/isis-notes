using System;
using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ISISNotesBackend.API.Controllers
{
    [Route("file")]
    public class FileController : Controller
    {
        private readonly IFacade _facade;
        private readonly IConfiguration _configuration;
        private string Path => _configuration["Database:StoredFilesPath"];

        public FileController(IFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }

        [Authorize]
        [Route("{userId}")]
        [HttpPost]
        public IActionResult AddFile(string userId, [FromBody] FileWithContent file)
        {
            try
            {
                Console.WriteLine(file.Content);
                return Ok(_facade.AddFile(userId, file, Path));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        [Authorize]
        [Route("{userId}/{fileId}")]
        [HttpGet]
        public IActionResult GetFile(string userId, string fileId)
        {
            try
            {
                return Ok(_facade.GetFile(userId, fileId, Path));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        [Authorize]
        [Route("{userId}/{fileId}")]
        [HttpDelete]
        public IActionResult DeleteFile(string userId, string fileId)
        {
            try
            {
                return Ok(_facade.DeleteFile(userId, fileId, Path));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}