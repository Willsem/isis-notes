using System;
using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Repositories
{
    public interface IUserNoteRepository
    {
        /// <summary>
        /// New user of note.
        /// </summary>
        /// <param name="changeUserId">Id of user, who wants to create new user of note.</param>
        /// <param name="userId">Id of created user.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="userRights">Rights of user.</param>
        /// <returns>New user of note.</returns>
        NoteAccessRight CreateUserNote(Guid changeUserId, Guid userId, Guid noteId, String userRights);
        /// <summary>
        /// Changes user rights.
        /// </summary>
        /// <param name="changeUserId">Id of user, who wants to change user rights.</param>
        /// <param name="userId">Id of changed user.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="userRights">New rights of user.</param>
        /// <returns>Changed user of note.</returns>
        NoteAccessRight ChangeUserNote(Guid changeUserId, Guid userId, Guid noteId, String userRights);
        /// <summary>
        /// Deletes user of note.
        /// </summary>
        /// <param name="changeUserId">Id of user, who wants to delete user of note.</param>
        /// <param name="userId">Id of deleted user.</param>
        /// <param name="noteId">Id of note.</param>
        /// <returns>Deleted user of note.</returns>
        NoteAccessRight DeleteUserNote(Guid changeUserId, Guid userId, Guid noteId);
    }
}