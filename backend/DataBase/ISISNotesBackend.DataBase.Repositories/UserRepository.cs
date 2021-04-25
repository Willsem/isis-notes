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

        public CoreModels.Session DeleteSession(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}