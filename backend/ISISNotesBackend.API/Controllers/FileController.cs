using System;
using System.IO;
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
        public NoteFileContent AddFile(string userId, [FromBody] FileWithContent file)
        {
            return _facade.AddFile(userId, file, Path);
        }
        
        [Authorize]
        [Route("{userId}/{fileId}")]
        public byte[] GetFile(string userId, string fileId)
        {
            return _facade.GetFile(userId, fileId, Path);
        }
        
        [Authorize]
        [Route("{userId}/{fileId}")]
        public NoteFileContent DeleteFile(string userId, string fileId)
        {
            return _facade.DeleteFile(userId, fileId, Path);
        }
    }
}