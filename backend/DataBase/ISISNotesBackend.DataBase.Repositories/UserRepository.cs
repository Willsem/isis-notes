using System;
using System.Collections.Generic;
using System.Linq;
using ISISNotesBackend.Core.Repositories;
using ISISNotesBackend.DataBase.NpgsqlContext;
using Microsoft.EntityFrameworkCore;
using DbModels = ISISNotesBackend.DataBase.Models;
using CoreModels = ISISNotesBackend.Core.Models;

namespace ISISNotesBackend.DataBase.Repositories
{
    public class UserRepository : IUserRepository
    { 
        private readonly ISISNotesContext _dbContext;
        
        public UserRepository(ISISNotesContext chatServiceContext)
        {
            _dbContext = chatServiceContext;
        }
        public IEnumerable<CoreModels.User> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public CoreModels.User CreateUser(CoreModels.UserWithLogin userWithLogin)
        {
            throw new System.NotImplementedException();
        }

        public CoreModels.User ChangeUser(CoreModels.UserWithLoginAndAvatar userWithLoginAndAvatar, string image)
        {
            throw new System.NotImplementedException();
        }

        public CoreModels.User? EnterUser(string name, string password)
        {
            throw new System.NotImplementedException();
        }

        public CoreModels.Session CreateSession(string token, string userId)
        {
            var session = new DbModels.Session(Guid.Parse(userId), token, DateTime.Now, true);
            
            var user = _dbContext.Users
                .Include(u => u.Sessions)
                .Include(u => u.UserPhoto)
                .First(u => u.Id == session.UserId);
            
            _dbContext.Sessions.Add(session);
            _dbContext.SaveChanges();

            return new CoreModels.Session(session.Id.ToString(),
                token, 
                new CoreModels.User(user.Id.ToString(), user.Name, user.Email, user.UserPhoto.Image), 
                session.CreatedAt);
        }
        
        public CoreModels.Session DeleteSession(string id)
        {
            var session = _dbContext.Sessions
                .First(s => s.Id.ToString() == id);

            var user = _dbContext.Users
                .Include(u => u.Sessions)
                .Include(u => u.UserPhoto)
                .First(u => u.Id == session.UserId);

            _dbContext.Sessions.Remove(session);
            _dbContext.SaveChanges();

            return new CoreModels.Session(session.Id.ToString(), 
                session.Token, 
                new CoreModels.User(user.Id.ToString(), user.Name, user.Email, user.UserPhoto.Image), 
                session.CreatedAt);
        }
    }
}