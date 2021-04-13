using System;
using System.Collections.Generic;
using ISISNotesBackend.Core.Models;

namespace ISISNotesBackend.Core.Repositories
{
    public interface INoteRepository
    {
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
    }
}