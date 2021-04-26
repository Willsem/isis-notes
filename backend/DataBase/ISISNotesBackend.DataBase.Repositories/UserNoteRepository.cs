using System;
using System.Linq;
using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;
using ISISNotesBackend.Core.Repositories;
using ISISNotesBackend.DataBase.NpgsqlContext;
using Microsoft.EntityFrameworkCore;
using DbModels = ISISNotesBackend.DataBase.Models;
using CoreModels = ISISNotesBackend.Core.Models;

namespace ISISNotesBackend.DataBase.Repositories
{
    public class UserNoteRepository : IUserNoteRepository
    {
        private readonly ISISNotesContext _dbContext;

        public UserNoteRepository(ISISNotesContext chatServiceContext)
        {
            _dbContext = chatServiceContext;
        }
        
        public NoteAccessRight CreateUserNote(Guid changeUserId, Guid userId, Guid noteId, UserRights userRights)
        {
            var user = _dbContext.Users
                .First(u => u.Id == userId);
            
            var note = _dbContext.Notes
                .First(n => n.Id == noteId);
            
            var userNote = new DbModels.UserNote((DbModels.Enums.UserRights) userRights, userId, user, noteId, note);

            _dbContext.UserNotes.Add(userNote);
            _dbContext.SaveChanges();
            
            return new NoteAccessRight(noteId.ToString(), 
                userId.ToString(),
                userRights);
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