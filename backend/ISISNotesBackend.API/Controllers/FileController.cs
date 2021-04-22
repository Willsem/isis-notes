using System;
using System.IO;
using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ISISNotesBackend.API.Controllers
{
    [Route("file")]
    public class FileController : Controller
    {
        private readonly IFacade _facade;
        private readonly IConfiguration _configuration;
        private string _path => _configuration["Database:StoredFilesPath"];

        public FileController(IFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }

        [Route("{userId}")]
        public NoteFileContent AddFile(string userId, [FromBody] FileWithContent file)
        {
            return null;
        }
        
        [Route("{userId}/{fileId}")]
        public byte[] GetFile(string userId, string fileId)
        {
            return null;
        }
        
        [Route("{userId}/{fileId}")]
        public NoteFileContent DeleteFile(string userId, string fileId)
        {
            return null;
        }
    }
}