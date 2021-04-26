using System;
using System.Linq;
using ISISNotesBackend.Core.Repositories;
using ISISNotesBackend.DataBase.NpgsqlContext;
using Microsoft.EntityFrameworkCore;
using DbModels = ISISNotesBackend.DataBase.Models;
using CoreModels = ISISNotesBackend.Core.Models;

namespace ISISNotesBackend.DataBase.Repositories
{
    public class RightsRepository : IRightsRepository
    {
        private readonly ISISNotesContext _dbContext;

        public RightsRepository(ISISNotesContext chatServiceContext)
        {
            _dbContext = chatServiceContext;
        }
        public bool CanUserReadNote(Guid userId, Guid noteId)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            bool can = false;
            if (userNote.Rights.HasFlag(DbModels.Enums.UserRights.author)) 
                can = true;
            else if (userNote.Rights.HasFlag(DbModels.Enums.UserRights.write))
                can = true;
            else if (userNote.Rights.HasFlag(DbModels.Enums.UserRights.read))
                can = true;

            return can;
        }

        public bool CanUserEditNote(Guid userId, Guid noteId)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);
            
            bool can = false;
            if (userNote.Rights.HasFlag(DbModels.Enums.UserRights.author)) 
                can = true;
            else if (userNote.Rights.HasFlag(DbModels.Enums.UserRights.write))
                can = true;

            return can;
        }

        public bool CanUserDeleteNote(Guid userId, Guid noteId)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            return userNote.Rights.HasFlag(DbModels.Enums.UserRights.author);
        }

        public bool CanUserAddUsersToNote(Guid userId, Guid noteId)
        {
            var userNote = _dbContext.UserNotes
                .Include(un => un.Note)
                    .ThenInclude(n => n.TextNote)
                .Include(un => un.User)
                    .ThenInclude(u => u.Passcode)
                .Include(un => un.User)
                    .ThenInclude(u => u.UserPhoto)
                .First(un => un.UserId == userId && un.NoteId == noteId);

            return userNote.Rights.HasFlag(DbModels.Enums.UserRights.author);
        }
    }
}