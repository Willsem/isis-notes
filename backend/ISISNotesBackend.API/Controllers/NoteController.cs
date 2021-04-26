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
        
        /// <summary>
        /// Возвращает все заметки пользователя.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, чьи заметки ищутся в хранилище и возвращаются.</param>
        /// <returns>Массив заметок пользователя.</returns>
        [Authorize]
        [Route("{userId}")]
        [HttpGet]
        public Note[] GetNotes(string userId)
        {
            return _facade.GetUserNotes(userId);
        }
        
        /// <summary>
        /// Создает заметку.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, создающего заметку.</param>
        /// <param name="note">Информация о заметке (идентификатор, имя, режим доступа), полученная из POST-запроса.</param>
        /// <returns>Результат действия Ok с информацией о созданной заметке в случае успеха, иначе - NotFound.</returns>
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
        
        /// <summary>
        /// Получает содержимое заметки.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, получающего содержимое заметки.</param>
        /// <param name="noteId">Идентификатор заметки, содержимое которой нужно получить.</param>
        /// <returns>Результат действия Ok с информацией о получаемой заметке в случае успеха, иначе - Forbid.</returns>
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
        
        /// <summary>
        /// Изменяет заметку и получает ее содержимое.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, изменяющего заметку.</param>
        /// <param name="noteId">Идентификатор изменяемой заметки.</param>
        /// <returns>Результат действия Ok с информацией о измененной заметке и ее содержимое в случае успеха, иначе - Forbid.</returns>
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
       
        /// <summary>
        /// Удаляет заметку.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, удаляющего заметку.</param>
        /// <param name="noteId">Идентификатор удаляемой заметки.</param>
        /// <returns>Результат действия Ok с информацией о удаленной заметке в случае успеха, иначе - Forbid.</returns>
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
        
        /// <summary>
        /// Добавляет права пользователю на заметку.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который добавляет права.</param>
        /// <param name="noteId">Идентификатор заметки, на которую распространяются выделенные пользователю права.</param>
        /// <param name="noteAccessRight">Новый режим доступа, получаемый из POST-запроса.</param>
        /// <returns>Результат действия Ok с информацией о заметке, на которые распространяются права в случае успеха, иначе - Forbid.</returns>
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
        
        /// <summary>
        /// Изменяет права пользователю на заметку.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, котороый меняет права.</param>
        /// <param name="noteId">Идентификатор заметки, на которую распространяются выделенные пользователю права.</param>
        /// <param name="noteAccessRight">Новый режим доступа, получаемый из POST-запроса.</param>
        /// <returns>Результат действия Ok с информацией о заметке, на которые распространяются права в случае успеха, иначе - Forbid.</returns>
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
        
        /// <summary>
        /// Удаляет права пользователя на заметку.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который удаляет права.</param>
        /// <param name="noteId">Идентификатор заметки, на которую распространяются выделенные пользователю права.</param>
        /// <param name="toUserId">Идентификатор пользователя, которому удаляют права.</param>
        /// <returns>Результат действия Ok с правами доступа к заметке, для которой происходило изменение в случае успеха, иначе - Forbid.</returns>
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