using System;
using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;
using ISISNotesBackend.Core.Repositories;

namespace ISISNotesBackend.DataBase.Repositories
{
    public class UserNoteRepository : IUserNoteRepository
    {
        public NoteAccessRight CreateUserNote(Guid changeUserId, Guid userId, Guid noteId, UserRights userRights)
        {
            throw new NotImplementedException();
        }

        public NoteAccessRight ChangeUserNote(Guid changeUserId, Guid userId, Guid noteId, UserRights userRights)
        {
            throw new NotImplementedException();
        }

        public NoteAccessRight DeleteUserNote(Guid changeUserId, Guid userId, Guid noteId)
        {
            throw new NotImplementedException();
        }
    }
}