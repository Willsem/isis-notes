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
            var dbUsers = _dbContext.Users
                .Include(u => u.Passcode)
                .Include(u => u.UserPhoto)
                .ToList();
            
            List<CoreModels.User> coreUsers = new List<CoreModels.User>();
            
            foreach (var user in dbUsers)
            {
                if (user.UserPhoto != null)
                    coreUsers.Add(new CoreModels.User(user.Id.ToString(),
                        user.Name,
                        user.Email,
                        user.UserPhoto.Image));
                else
                    coreUsers.Add(new CoreModels.User(user.Id.ToString(),
                        user.Name,
                        user.Email,
                        null));
            }

            return coreUsers;
        }

        public CoreModels.User GetUser(string userId)
        {
            var user = _dbContext.Users
                .Include(u => u.Passcode)
                .Include(u => u.UserPhoto)
                .First(u => u.Id.ToString() == userId);

            if (user.UserPhoto != null)
                return new CoreModels.User(user.Id.ToString(),
                    user.Name,
                    user.Email,
                    user.UserPhoto.Image);
            else
                return new CoreModels.User(user.Id.ToString(),
                    user.Name,
                    user.Email,
                    null);
        }

        public CoreModels.User CreateUser(CoreModels.UserWithLogin userWithLogin)
        {
            var user = new DbModels.User(userWithLogin.User.Username,
                userWithLogin.User.Email,
                DateTime.Now);
            
            var passcode = new DbModels.Passcode(user.Id, userWithLogin.Login.Password);

            _dbContext.Users.Add(user);
            _dbContext.Passcodes.Add(passcode);
            _dbContext.SaveChanges();
            
            return new CoreModels.User(user.Id.ToString(),
                user.Name,
                user.Email,
                null);
        }

        public CoreModels.User ChangeUser(CoreModels.UserWithLoginAndAvatar userWithLoginAndAvatar, string image)
        {
            var user = _dbContext.Users
                .Include(u => u.Passcode)
                .Include(u => u.UserPhoto)
                .First(u => u.Id.ToString() == userWithLoginAndAvatar.User.Id);
            
            user.Name = userWithLoginAndAvatar.User.Username;
            user.Email = userWithLoginAndAvatar.User.Email;
       
            if (user.UserPhoto == null)
            {
                var userPhoto = new DbModels.UserPhoto(user.Id, image);
                _dbContext.UserPhotos.Add(userPhoto);
            }
            else
            {
                var userPhoto = _dbContext.UserPhotos
                    .First(up => up.Id == user.Id);
                userPhoto.Image = image;
                _dbContext.Entry(userPhoto).State = EntityState.Modified;
            }

            var passcode = _dbContext.Passcodes
                .First(p => p.Id == user.Id);

            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.Entry(passcode).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new CoreModels.User(user.Id.ToString(),
                user.Name,
                user.Email,
                image);
        }

        public CoreModels.User? EnterUser(string name, string password)
        {
            var user = _dbContext.Users
                .Include(u => u.Passcode)
                .Include(u => u.UserPhoto)
                .First(u => u.Name == name);
            
            var passcode = _dbContext.Passcodes
                .First(p => p.Id == user.Id);
            
            if (user != null && passcode != null)
                if (passcode.Password == password)
                    if (user.UserPhoto != null)
                        return new CoreModels.User(user.Id.ToString(),
                            user.Name,
                            user.Email,
                            user.UserPhoto.Image);
                    else
                        return new CoreModels.User(user.Id.ToString(),
                            user.Name,
                            user.Email,
                            null);
            return null;
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
            
            if (user.UserPhoto != null)
                return new CoreModels.Session(session.Id.ToString(),
                    token, 
                    new CoreModels.User(user.Id.ToString(), user.Name, user.Email, user.UserPhoto.Image), 
                    session.CreatedAt);
            else
                return new CoreModels.Session(session.Id.ToString(),
                    token, 
                    new CoreModels.User(user.Id.ToString(), user.Name, user.Email, null), 
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

            if (user.UserPhoto != null)
                return new CoreModels.Session(session.Id.ToString(), 
                    session.Token, 
                    new CoreModels.User(user.Id.ToString(), user.Name, user.Email, user.UserPhoto.Image), 
                    session.CreatedAt);
            else
                return new CoreModels.Session(session.Id.ToString(), 
                    session.Token, 
                    new CoreModels.User(user.Id.ToString(), user.Name, user.Email, null), 
                    session.CreatedAt);
        }
    }
}