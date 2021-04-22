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
        private string Path => _configuration["Database:StoredFilesPath"];

        public NoteController(IFacade facade, IConfiguration configuration)
        {
            _facade = facade;
            _configuration = configuration;
        }
        
        [Route("{userId}")]
        public Note[] GetNotes(string userId)
        {
            return _facade.GetUserNotes(userId);
        }
        
        [Route("{userId}")]
        public Note CreateNote(string userId, [FromBody] Note note)
        {
            return _facade.CreateNote(userId, note.Name);
        }
        
        [Route("{userId}/{noteId}")]
        public NoteContent[] GetNoteContent(string userId, string noteId)
        {
            return _facade.GetNoteContent(userId, noteId, Path);
        }
        
        [Route("{userId}/{noteId}")]
        public NoteWithContent ChangeNote(string userId, string noteId, [FromBody] NoteWithContent note)
        {
            _facade.ChangeNoteName(userId, noteId, note.Note.Name);
            return _facade.ChangeNoteText(userId, noteId, note.NoteContent, Path);
        }
        
        [Route("{userId}/{noteId}")]
        public Note DeleteNote(string userId, string noteId)
        {
            return _facade.DeleteNote(userId, noteId);
        }
        
        [Route("{userId}/{noteId}/permission")]
        public NoteAccessRight AddUserRights(string userId, string noteId, [FromBody] NoteAccessRight noteAccessRight)
        {
            return _facade.CreateUserNote(userId, noteAccessRight.UserId, noteAccessRight.NoteId, noteAccessRight.Rights);
        }
        
        [Route("{userId}/{noteId}/permission")]
        public NoteAccessRight EditUserRights(string userId, string noteId, [FromBody] NoteAccessRight noteAccessRight)
        {
            return _facade.ChangeUserNote(userId, noteAccessRight.UserId, noteAccessRight.NoteId, noteAccessRight.Rights);
        }
        
        [Route("{userId}/{noteId}/permission/{toUserId}")]
        public NoteAccessRight DeleteUserRights(string userId, string noteId, string toUserId)
        {
            return _facade.DeleteUserNote(userId, toUserId, noteId);
        }
    }
}