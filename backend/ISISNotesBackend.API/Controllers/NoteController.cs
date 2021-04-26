using System;
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
        public IActionResult CreateNote(string userId, [FromBody] Note note)
        {
            try
            {
                return Ok(_facade.CreateNote(userId, note.Name));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        
        [Authorize]
        [Route("{userId}/{noteId}")]
        [HttpGet]
        public IActionResult GetNoteContent(string userId, string noteId)
        {
            try
            {
                return Ok(_facade.GetNoteContent(userId, noteId));
            }
            catch (Exception)
            {
                return Forbid();
            }
        }
        
        [Authorize]
        [Route("{userId}/{noteId}")]
        [HttpPatch]
        public IActionResult ChangeNote(string userId, string noteId, [FromBody] NoteWithContent note)
        {
            try
            {
                _facade.ChangeNoteName(userId, noteId, note.Note.Name);
                return Ok(_facade.ChangeNoteText(userId, noteId, note.NoteContent));
            }
            catch (Exception)
            {
                return Forbid();
            }
        }
        
        [Authorize]
        [Route("{userId}/{noteId}")]
        [HttpDelete]
        public IActionResult DeleteNote(string userId, string noteId)
        {
            try
            {
                return Ok(_facade.DeleteNote(userId, noteId));
            }
            catch (Exception)
            {
                return Forbid();
            }
        }
        
        [Authorize]
        [Route("{userId}/{noteId}/permission")]
        [HttpPost]
        public IActionResult AddUserRights(string userId, string noteId, [FromBody] NoteAccessRight noteAccessRight)
        {
            try
            {
                return Ok(_facade.CreateUserNote(userId, noteAccessRight.UserId, noteAccessRight.NoteId, noteAccessRight.Rights));
            }
            catch (Exception)
            {
                return Forbid();
            }
        }
        
        [Authorize]
        [Route("{userId}/{noteId}/permission")]
        [HttpPatch]
        public IActionResult EditUserRights(string userId, string noteId, [FromBody] NoteAccessRight noteAccessRight)
        {
            try
            {
                return Ok(_facade.ChangeUserNote(userId, noteAccessRight.UserId, noteAccessRight.NoteId, noteAccessRight.Rights));
            }
            catch (Exception)
            {
                return Forbid();
            }
        }
        
        [Authorize]
        [Route("{userId}/{noteId}/permission/{toUserId}")]
        [HttpDelete]
        public IActionResult DeleteUserRights(string userId, string noteId, string toUserId)
        {
            try
            {
                return Ok(_facade.DeleteUserNote(userId, toUserId, noteId));
            }
            catch (Exception)
            {
                return Forbid();
            }
        }
    }
}