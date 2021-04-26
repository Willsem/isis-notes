using System;

namespace ISISNotesBackend.Core.Repositories
{
    public interface IRightsRepository
    {
        /// <summary>
        /// Проверяет, может ли пользователь прочитать заметку
        /// </summary>
        /// <param name="userId">Пользователь.</param>
        /// <param name="noteId">Заметка.</param>
        /// <returns>True, если пользователь имеет право на чтение, иначе - False.</returns>
        bool CanUserReadNote(Guid userId, Guid noteId);
        /// <summary>
        /// Проверяет, может ли пользователь изменять заметку
        /// </summary>
        /// <param name="userId">Пользователь.</param>
        /// <param name="noteId">Заметка.</param>
        /// <returns>True, если пользователь имеет право на редактирование, иначе - False.</returns>
        bool CanUserEditNote(Guid userId, Guid noteId);
        /// <summary>
        /// Проверяет, может ли пользователь удалить заметку
        /// </summary>
        /// <param name="userId">Пользователь.</param>
        /// <param name="noteId">Заметка.</param>
        /// <returns>True, если пользователь имеет право на удаление, иначе - False.</returns>
        bool CanUserDeleteNote(Guid userId, Guid noteId);
        /// <summary>
        /// Проверяет, может ли пользователь добавить пользователей
        /// </summary>
        /// <param name="userId">Пользователь.</param>
        /// <param name="noteId">Заметка.</param>
        /// <returns>True, если пользователь имеет право на добавление пользователей, иначе - False.</returns>
        bool CanUserAddUsersToNote(Guid userId, Guid noteId);
    }
}