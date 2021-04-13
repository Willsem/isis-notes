using System;
using System.Collections.Generic;
using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core
{
    public interface IFacade
    {
        #region NoteRepository
        /// <summary>
        /// Gets all notes of user.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <returns>Notes of user.</returns>
        IEnumerable<Note> GetUserNotes(Guid userId);
        /// <summary>
        /// Creates a new note.
        /// </summary>
        /// <param name="userId">Id of user, who creates a note.</param>
        /// <param name="name">Name of a note.</param>
        /// <returns>Created note.</returns>
        Note CreateNote(Guid userId, String name);
        /// <summary>
        /// Gets text content of note.
        /// </summary>
        /// <param name="userId">Id of user, who wants to get the content.</param>
        /// <param name="noteId">Id of note.</param>
        /// <returns>Text of note.</returns>
        TextNote GetNoteContent(Guid userId, Guid noteId);
        /// <summary>
        /// Changes text content of note.
        /// </summary>
        /// <param name="userId">Id of user, who wants to change the content.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="text">New text.</param>
        /// <returns>Text of note.</returns>
        TextNote ChangeNoteText(Guid userId, Guid noteId, String text);
        /// <summary>
        /// Changes name of note.
        /// </summary>
        /// <param name="userId">Id of user, who wants to edit the content.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="name">New name.</param>
        /// <returns>Note.</returns>
        Note ChangeNoteName(Guid userId, Guid noteId, String name);
        /// <summary>
        /// Deletes note.
        /// </summary>
        /// <param name="userId">Id of user, who wants to delete note.</param>
        /// <param name="noteId">Id of note.</param>
        /// <returns>Deleted note.</returns>
        Note DeleteNote(Guid userId, Guid noteId);
        /// <summary>
        /// Adds file to note.
        /// </summary>
        /// <param name="userId">Id of user, who wants to add file to note.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="filePath">Path of file.</param>
        /// <param name="fileType">Type of file.</param>
        /// <returns>Added file.</returns>
        File AddFile(Guid userId, Guid noteId, String filePath, String fileType);
        /// <summary>
        /// Gets file by Id.
        /// </summary>
        /// <param name="userId">Id of user, who wants to get file.</param>
        /// <param name="fileId">Id of file.</param>
        /// <returns>File.</returns>
        File GetFile(Guid userId, Guid fileId);
        /// <summary>
        /// Deletes file.
        /// </summary>
        /// <param name="userId">Id of user, who wants to delete file.</param>
        /// <param name="fileId">Id of file.</param>
        /// <returns>Deleted file.</returns>
        File DeleteFile(Guid userId, Guid fileId);
        #endregion

        #region UserRepository
        /// <summary>
        /// Gets all users of ISISNotes.
        /// </summary>
        /// <returns>All users.</returns>
        IEnumerable<User> GetAllUsers();
        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="name">Name of new user.</param>
        /// <param name="email">Email of new user.</param>
        /// <param name="password">Password of new user.</param>
        /// <param name="image">Image of new user.</param>
        /// <returns>Created user.</returns>
        User CreateUser(String name, String email, String password, String? image);
        /// <summary>
        /// Changes user.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <param name="name">Name of user.</param>
        /// <param name="email">Email of user.</param>
        /// <param name="password">Password of user.</param>
        /// <param name="image">Image of user.</param>
        /// <returns>User.</returns>
        User ChangeUser(Guid userId, String name, String email, String password, String image);
        #endregion

        #region UserNoteRepository
        /// <summary>
        /// Correct name and password of user?
        /// </summary>
        /// <param name="name">Name of entering user.</param>
        /// <param name="password">Password of entering user.</param>
        /// <returns>User or null.</returns>
        User? EnterUser(String name, String password);
        /// <summary>
        /// New user of note.
        /// </summary>
        /// <param name="changeUserId">Id of user, who wants to create new user of note.</param>
        /// <param name="userId">Id of created user.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="userRights">Rights of user.</param>
        /// <returns>New user of note.</returns>
        UserNote CreateUserNote(String changeUserId, String userId, String noteId, UserRights userRights);
        /// <summary>
        /// Changes user rights.
        /// </summary>
        /// <param name="changeUserId">Id of user, who wants to change user rights.</param>
        /// <param name="userId">Id of changed user.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="userRights">New rights of user.</param>
        /// <returns>Changed user of note.</returns>
        UserNote ChangeUserNote(String changeUserId, String userId, String noteId, UserRights userRights);
        /// <summary>
        /// Deletes user of note.
        /// </summary>
        /// <param name="changeUserId">Id of user, who wants to delete user of note.</param>
        /// <param name="userId">Id of deleted user.</param>
        /// <param name="noteId">Id of note.</param>
        /// <returns>Deleted user of note.</returns>
        UserNote DeleteUserNote(String changeUserId, String userId, String noteId);
        #endregion
    }
}