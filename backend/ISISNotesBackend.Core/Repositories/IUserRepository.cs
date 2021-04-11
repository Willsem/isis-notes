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
        /// <param name="name">Name of new user.</param>
        /// <param name="email">Email of new user.</param>
        /// <param name="password">Password of new user.</param>
        /// <param name="image">Image of new user.</param>
        /// <returns>Created user.</returns>
        User CreateUser(String name, String email, String password, String? image);
        /// <summary>
        /// Changes user.
        /// </summary>
        /// <param name="userId">Id of user.</param>
        /// <param name="name">Name of user.</param>
        /// <param name="email">Email of user.</param>
        /// <param name="password">Password of user.</param>
        /// <param name="image">Image of user.</param>
        /// <returns>User.</returns>
        User ChangeUser(Guid userId, String name, String email, String password, String image);
    }
}