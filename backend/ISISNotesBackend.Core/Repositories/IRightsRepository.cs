using System;

namespace ISISNotesBackend.Core.Repositories
{
    public interface IRightsRepository
    {
        /// <summary>
        /// Can user read note?
        /// </summary>
        /// <param name="userId">User.</param>
        /// <param name="noteId">Note.</param>
        /// <returns>If can - true, else - false.</returns>
        bool CanUserReadNote(Guid userId, Guid noteId);
        /// <summary>
        /// Can user edit note?
        /// </summary>
        /// <param name="userId">User.</param>
        /// <param name="noteId">Note.</param>
        /// <returns>If can - true, else - false.</returns>
        bool CanUserEditNote(Guid userId, Guid noteId);
        /// <summary>
        /// Can user delete note?
        /// </summary>
        /// <param name="userId">User.</param>
        /// <param name="noteId">Note.</param>
        /// <returns>If can - true, else - false.</returns>
        bool CanUserDeleteNote(Guid userId, Guid noteId);
        /// <summary>
        /// Can user add users to note?
        /// </summary>
        /// <param name="userId">User.</param>
        /// <param name="noteId">Note.</param>
        /// <returns>If can - true, else - false.</returns>
        bool CanUserAddUsersToNote(Guid userId, Guid noteId);
    }
}