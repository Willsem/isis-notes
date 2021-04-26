using System;
using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core.Repositories
{
    public interface IUserNoteRepository
    {
        /// <summary>
        /// Создает пользователя заметки.
        /// </summary>
        /// <param name="changeUserId">Идентификатор пользователя, который хочет создать нового пользователя заметки.</param>
        /// <param name="userId">Идентификатор созданной заметки.</param>
        /// <param name="noteId">Идентификатор заметки.</param>
        /// <param name="userRights">Права пользователя.</param>
        /// <returns>Информация о заметке, на которые распространяются права.</returns>
        NoteAccessRight CreateUserNote(Guid changeUserId, Guid userId, Guid noteId, UserRights userRights);
        /// <summary>
        /// Изменяет права пользователя на заметку.
        /// </summary>
        /// <param name="changeUserId">Идентификатор пользователя, который хочет изменить права пользователя.</param>
        /// <param name="userId">Идентификатор измененного пользователя.</param>
        /// <param name="noteId">Идентификатор заметки.</param>
        /// <param name="userRights">Новые права пользователя.</param>
        /// <returns>Информация о заметке, на которые распространяются права.</returns>
        NoteAccessRight ChangeUserNote(Guid changeUserId, Guid userId, Guid noteId, UserRights userRights);
        /// <summary>
        /// Удаляет пользователя заметки.
        /// </summary>
        /// <param name="changeUserId">Идентификатор пользователя, который хочет удалить пользователя заметки.</param>
        /// <param name="userId">Идентификатор удаленного пользователя.</param>
        /// <param name="noteId">Идентификатор заметки.</param>
        /// <returns>Информация о заметке, на которые распространяются права.</returns>
        NoteAccessRight DeleteUserNote(Guid changeUserId, Guid userId, Guid noteId);
    }
}