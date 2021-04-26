using System;
using System.Linq;
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
        
        public CoreModels.NoteAccessRight CreateUserNote(Guid changeUserId, Guid userId, Guid noteId, 
            CoreModels.Enums.UserRights userRights)
        {
            var user = _dbContext.Users
                .First(u => u.Id == userId);
            var note = _dbContext.Notes
                .First(n => n.Id == noteId);
            var dbUserRights =
                (DbModels.Enums.UserRights) Enum.Parse(typeof(DbModels.Enums.UserRights), userRights.ToString());
            var userNote = new DbModels.UserNote(dbUserRights, userId, user, noteId, note);

            _dbContext.UserNotes.Add(userNote);
            _dbContext.SaveChanges();
            
            return new CoreModels.NoteAccessRight(userNote.NoteId.ToString(), 
                userNote.UserId.ToString(),
                userRights);
        }

        public CoreModels.NoteAccessRight ChangeUserNote(Guid changeUserId, Guid userId, Guid noteId, 
            CoreModels.Enums.UserRights userRights)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            userNote.Rights = (DbModels.Enums.UserRights) Enum.Parse(typeof(DbModels.Enums.UserRights), userRights.ToString());
            _dbContext.Entry(userNote).State = EntityState.Modified;
            _dbContext.SaveChanges();
            
            return new CoreModels.NoteAccessRight(userNote.NoteId.ToString(), 
                userNote.UserId.ToString(),
                userRights);
        }

        public CoreModels.NoteAccessRight DeleteUserNote(Guid changeUserId, Guid userId, Guid noteId)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            _dbContext.UserNotes.Remove(userNote);
            _dbContext.SaveChanges();
            
            return new CoreModels.NoteAccessRight(userNote.NoteId.ToString(), 
                userNote.UserId.ToString(), 
                (CoreModels.Enums.UserRights) userNote.Rights);
        }
    }
}