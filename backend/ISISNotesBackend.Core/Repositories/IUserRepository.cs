using System;
using System.Collections.Generic;
using ISISNotesBackend.Core.Models;

namespace ISISNotesBackend.Core.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets all users of ISISNotes.
        /// </summary>
        /// <returns>All users.</returns>
        IEnumerable<User> GetAllUsers();
        /// <summary>
        /// Creates new user.
        /// </summary>
        /// <param name="userWithLogin">User.</param>
        /// <returns>Created user.</returns>
        User CreateUser(UserWithLogin userWithLogin);
        /// <summary>
        /// Changes user.
        /// </summary>
        /// <param name="userWithLoginAndAvatar">User.</param>
        /// <returns>User.</returns>
        User ChangeUser(UserWithLoginAndAvatar userWithLoginAndAvatar);
    }
}