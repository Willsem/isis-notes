using System;
using System.Collections.Generic;
using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core
{
    public interface IFacade
    {
        #region NoteRepository

        IEnumerable<Note> GetUserNotes(Guid userId);
        Note CreateNote(Guid userId, String name);
        TextNote GetNoteContent(Guid userId, Guid noteId);
        TextNote EditNoteText(Guid userId, Guid noteId, String text);
        Note EditNoteName(Guid noteId, String name);
        Note DeleteNote(Guid userId, Guid noteId);
        
        File AddFile(Guid noteId, String filePath, String fileType);
        File GetFile(Guid fileId);
        void DeleteFile(Guid fileId);

        #endregion

        #region UserRepository

        IEnumerable<User> GetAllUsers();
        User AddUser(String name, String email, String password, String image);
        User EditUser(Guid userId, String name, String email, String password, String image);

        #endregion

        #region UserNoteRepository

        User EnterUser(String name, String password);
        UserNote AddUserNote(String changeUserId, String userId, String noteId, UserRights userRights);
        UserNote EditUserNote(String changeUserId, String userId, String noteId, UserRights userRights);
        UserNote DeleteUserNote(String changeUserId, String userId, String noteId, UserRights userRights);

        #endregion
    }
}