using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ISISNotesBackend.API.Controllers
{
    [Route("notes")]
    public class NoteController : Controller
    {
        private readonly IFacade _facade;
        private readonly IConfiguration _configuration;
        private string _path => _configuration["Database:StoredFilesPath"];

        public NoteController(IFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }
        
        [Route("{userId}")]
        public Note[] GetNotes(string userId)
        {
            return null;
        }
        
        [Route("{userId}")]
        public Note CreateNote(string userId, [FromBody] Note note)
        {
            return null;
        }
        
        [Route("{userId}/{noteId}")]
        public NoteContent[] GetNoteContent(string userId, string noteId)
        {
            return null;
        }
        
        [Route("{userId}/{noteId}")]
        public NoteWithContent ChangeNote(string userId, string noteId, [FromBody] NoteWithContent note)
        {
            return null;
        }
        
        [Route("{userId}/{noteId}")]
        public Note DeleteNote(string userId, string noteId)
        {
            return null;
        }
        
        [Route("{userId}/{noteId}/permission")]
        public NoteAccessRight AddUserRights(string userId, string noteId, [FromBody] NoteAccessRight noteAccessRight)
        {
            return null;
        }
        
        [Route("{userId}/{noteId}/permission")]
        public NoteAccessRight EditUserRights(string userId, string noteId, [FromBody] NoteAccessRight noteAccessRight)
        {
            return null;
        }
        
        [Route("{userId}/{noteId}/permission/{toUserId}")]
        public NoteAccessRight DeleteUserRights(string userId, string noteId, string toUserId)
        {
            return null;
        }
    }
}