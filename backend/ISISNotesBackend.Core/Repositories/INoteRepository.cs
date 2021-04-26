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
        /// Gets content of note.
        /// </summary>
        /// <param name="userId">Id of user, who wants to get the content.</param>
        /// <param name="noteId">Id of note.</param>
        /// <returns>Text of note.</returns>
        IEnumerable<INoteContent> GetNoteContent(Guid userId, Guid noteId);
        /// <summary>
        /// Changes text content of note.
        /// </summary>
        /// <param name="userId">Id of user, who wants to change the content.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="noteContent">New content.</param>
        /// <returns>Text of note.</returns>
        NoteAllContent ChangeNoteText(Guid userId, Guid noteId, INoteContent[] noteContent);
        /// <summary>
        /// Changes name of note.
        /// </summary>
        /// <param name="userId">Id of user, who wants to edit the content.</param>
        /// <param name="noteId">Id of note.</param>
        /// <param name="name">New name.</param>
        /// <returns>Note.</returns>
        NoteAllContent ChangeNoteName(Guid userId, Guid noteId, String name);
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
        /// <param name="file">File.</param>
        /// <returns>Added file.</returns>
        NoteFileContent AddFile(Guid userId, NoteFileContent file);
        /// <summary>
        /// Gets file by Id.
        /// </summary>
        /// <param name="userId">Id of user, who wants to get file.</param>
        /// <param name="fileId">Id of file.</param>
        /// <returns>File.</returns>
        NoteFileContent GetFile(Guid userId, Guid fileId);
        /// <summary>
        /// Gets file by Name.
        /// </summary>
        /// <param name="filename">File name.</param>
        /// <returns>File.</returns>
        NoteFileContent GetFileByName(String filename);
        /// <summary>
        /// Deletes file.
        /// </summary>
        /// <param name="userId">Id of user, who wants to delete file.</param>
        /// <param name="fileId">Id of file.</param>
        /// <returns>Deleted file.</returns>
        NoteFileContent DeleteFile(Guid userId, Guid fileId);
    }
}