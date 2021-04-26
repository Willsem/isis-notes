using ISISNotesBackend.Core;
using ISISNotesBackend.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ISISNotesBackend.API.Controllers
{
    [Route("notes")]
    public class NoteController : Controller
    {
        private readonly IFacade _facade;

        public NoteController(IFacade facade, IConfiguration configuration)
        {
            _facade = facade;
        }
        
        [Authorize]
        [Route("{userId}")]
        [HttpGet]
        public Note[] GetNotes(string userId)
        {
            return _facade.GetUserNotes(userId);
        }
        
        [Authorize]
        [Route("{userId}")]
        [HttpPost]
        public Note CreateNote(string userId, [FromBody] Note note)
        {
            return _facade.CreateNote(userId, note.Name);
        }
        
        [Authorize]
        [Route("{userId}/{noteId}")]
        [HttpGet]
        public NoteContent[] GetNoteContent(string userId, string noteId)
        {
            return _facade.GetNoteContent(userId, noteId);
        }
        
        [Authorize]
        [Route("{userId}/{noteId}")]
        [HttpPatch]
        public NoteWithContent ChangeNote(string userId, string noteId, [FromBody] NoteWithContent note)
        {
            _facade.ChangeNoteName(userId, noteId, note.Note.Name);
            return _facade.ChangeNoteText(userId, noteId, note.NoteContent);
        }
        
        [Authorize]
        [Route("{userId}/{noteId}")]
        [HttpDelete]
        public Note DeleteNote(string userId, string noteId)
        {
            return _facade.DeleteNote(userId, noteId);
        }
        
        [Authorize]
        [Route("{userId}/{noteId}/permission")]
        [HttpPost]
        public NoteAccessRight AddUserRights(string userId, string noteId, [FromBody] NoteAccessRight noteAccessRight)
        {
            return _facade.CreateUserNote(userId, noteAccessRight.UserId, noteAccessRight.NoteId, noteAccessRight.Rights);
        }
        
        [Authorize]
        [Route("{userId}/{noteId}/permission")]
        [HttpPatch]
        public NoteAccessRight EditUserRights(string userId, string noteId, [FromBody] NoteAccessRight noteAccessRight)
        {
            return _facade.ChangeUserNote(userId, noteAccessRight.UserId, noteAccessRight.NoteId, noteAccessRight.Rights);
        }
        
        [Authorize]
        [Route("{userId}/{noteId}/permission/{toUserId}")]
        [HttpDelete]
        public NoteAccessRight DeleteUserRights(string userId, string noteId, string toUserId)
        {
            return _facade.DeleteUserNote(userId, toUserId, noteId);
        }
    }
}