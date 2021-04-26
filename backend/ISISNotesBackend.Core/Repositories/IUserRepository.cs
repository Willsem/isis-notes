using System;
using System.Collections.Generic;
using ISISNotesBackend.Core.Models;

namespace ISISNotesBackend.Core.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Получить всех пользователей ISISNotes.
        /// </summary>
        /// <returns>Все пользователи.</returns>
        IEnumerable<User> GetAllUsers();
        /// <summary>
        /// Получить пользователя по идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Пользователь.</returns>
        User GetUser(String userId);
        /// <summary>
        /// Создает нового пользователя.
        /// </summary>
        /// <param name="userWithLogin">Пользователь.</param>
        /// <returns>Созданный пользователь.</returns>
        User CreateUser(UserWithLogin userWithLogin);
        /// <summary>
        /// Изменяет пользователя.
        /// </summary>
        /// <param name="userWithLoginAndAvatar">Пользователь.</param>
        /// <param name="image">Путь к изображению.</param>
        /// <returns>Пользователь.</returns>
        User ChangeUser(UserWithLoginAndAvatar userWithLoginAndAvatar, String image);
        /// <summary>
        /// Проверяет, существует ли пользователь
        /// </summary>
        /// <param name="name">Имя входящего пользователя.</param>
        /// <param name="password">Пароль входящего пользователя.</param>
        /// <returns>Пользователь, если существует, иначе - Null.</returns>
        User? EnterUser(String name, String password);
        /// <summary>
        /// Создает сессию после входе в систему.
        /// </summary>
        /// <param name="token">JWT-токен сессии</param>
        /// <param name="userId">Идентификатор пользователя, для которого создается сессия.</param>
        /// <returns>Созданная сессия.</returns>
        Session CreateSession(String token, String userId);
        /// <summary>
        /// Удаляет сессию при выходе из системы.
        /// </summary>
        /// <param name="id">Идентификатор сессии, которую удаляют</param>
        /// <returns>Удаленная сессия.</returns>
        Session DeleteSession(string id);
    }
}