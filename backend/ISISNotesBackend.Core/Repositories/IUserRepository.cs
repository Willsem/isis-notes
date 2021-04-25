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
        /// <param name="image">Path to image.</param>
        /// <returns>User.</returns>
        User ChangeUser(UserWithLoginAndAvatar userWithLoginAndAvatar, String image);
        /// <summary>
        /// Correct name and password of user?
        /// </summary>
        /// <param name="name">Name of entering user.</param>
        /// <param name="password">Password of entering user.</param>
        /// <returns>User or null.</returns>
        User? EnterUser(String name, String password);
        /// <summary>
        /// Create session after login.
        /// </summary>
        /// <param name="token">JSON Web Token of session.</param>
        /// <param name="userId">User that logged in.</param>
        /// <returns>Deleted session.</returns>
        Session CreateSession(String token, String userId);
        /// <summary>
        /// Delete session after logout.
        /// </summary>
        /// <param name="id">Id of session.</param>
        /// <returns>Deleted session.</returns>
        Session DeleteSession(string id);
    }
}