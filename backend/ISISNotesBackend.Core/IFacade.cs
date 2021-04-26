using System;
using ISISNotesBackend.Core.Models;
using ISISNotesBackend.Core.Models.Enums;

namespace ISISNotesBackend.Core
{
    public interface IFacade
    {
        #region NoteRepository
        /// <summary>
        /// Получение все заметок пользователя.
        /// </summary>
        /// <param name="userId">Id пользователя.</param>
        /// <returns>Список замето.</returns>
        Note[] GetUserNotes(string userId);
        /// <summary>
        /// Создание новой заметки.
        /// </summary>
        /// <param name="userId">Id пользователя - автора.</param>
        /// <param name="name">Имя заметки..</param>
        /// <returns>Созданная заметка.</returns>
        Note CreateNote(string userId, String name);
        /// <summary>
        /// Получение содержания заметки.
        /// </summary>
        /// <param name="userId">Id пользователя - кто хочет получить.</param>
        /// <param name="noteId">Id заметки.</param>
        /// <returns>Содержание заметки.</returns>
        NoteContent[] GetNoteContent(string userId, string noteId);
        /// <summary>
        /// Изменение текста заметки.
        /// </summary>
        /// <param name="userId">Id пользователя - кто хочет изменить.</param>
        /// <param name="noteId">Id заметки.</param>
        /// <param name="noteContent">Новый контент.</param>
        /// <returns>Измененная заметка.</returns>
        NoteWithContent ChangeNoteText(string userId, string noteId, NoteContent[] noteContent);
        /// <summary>
        /// Изменение имени заметки.
        /// </summary>
        /// <param name="userId">Id пользователя - кто хочет изменить.</param>
        /// <param name="noteId">Id заметки.</param>
        /// <param name="name">Новое имя.</param>
        /// <returns>Измененная заметка.</returns>
        NoteWithContent ChangeNoteName(string userId, string noteId, String name);
        /// <summary>
        /// Удаление заметку.
        /// </summary>
        /// <param name="userId">Id пользователя - кто хочет удалить.</param>
        /// <param name="noteId">Id заметки.</param>
        /// <returns>Удаленная заметка.</returns>
        Note DeleteNote(string userId, string noteId);
        /// <summary>
        /// Добавление файла.
        /// </summary>
        /// <param name="userId">Id пользователя - кто хочет добавить файл.</param>
        /// <param name="file">Файл.</param>
        /// <param name="path">Путь до хранилища файлов.</param>
        /// <returns>Добавленный файл..</returns>
        NoteFileContent AddFile(string userId, FileWithContent file, string path);
        /// <summary>
        /// Получение файла по Id.
        /// </summary>
        /// <param name="userId">Id пользователя - кто хочет получить файл.</param>
        /// <param name="fileId">Id файла.</param>
        /// <param name="path">Путь до хранилища файлов.</param>
        /// <returns>Содержимое файла.</returns>
        byte[] GetFile(string userId, string fileId, string path);
        /// <summary>
        /// Удаление файла.
        /// </summary>
        /// <param name="userId">Id пользователя - кто хочет удалить файл.</param>
        /// <param name="fileId">Id файла.</param>
        /// <param name="path">Путь до хранилища файлов.</param>
        /// <returns>Содержимое файла.</returns>
        NoteFileContent DeleteFile(string userId, string fileId, string path);
        #endregion

        #region UserRepository
        /// <summary>
        /// Получение всех пользователей ISISNotes.
        /// </summary>
        /// <returns>Пользователи.</returns>
        User[] GetAllUsers();
        /// <summary>
        /// Создание пользователя.
        /// </summary>
        /// <param name="userWithLogin">Данные пользователя.</param>
        /// <returns>Созданный пользователь.</returns>
        User CreateUser(UserWithLogin userWithLogin);
        /// <summary>
        /// Изменение пользователя.
        /// </summary>
        /// <param name="userWithLoginAndAvatar">Новые данные пользователя.</param>
        /// <param name="path">Путь до хранилища файлов.</param>
        /// <returns>Пользователь.</returns>
        User ChangeUser(UserWithLoginAndAvatar userWithLoginAndAvatar, string path);
        /// <summary>
        /// Создание сессии.
        /// </summary>
        /// <param name="token">JSON веб токен сессии.</param>
        /// <param name="userId">Id пользователя, который пытается залогиниться.</param>
        /// <returns>Сессия.</returns>
        Session CreateSession(String token, String userId);
        /// <summary>
        /// Удаление сессии, после завершения сеанса пользователе.
        /// </summary>
        /// <param name="id">Id сессии.</param>
        /// <returns>Удаленная сессия.</returns>
        Session DeleteSession(String id);
        #endregion

        #region UserNoteRepository
        /// <summary>
        /// Проверка корректности имени пользователя и пароля.
        /// </summary>
        /// <param name="name">Имя пользователя.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Пользователь или null.</returns>
        User? EnterUser(String name, String password);
        /// <summary>
        /// Предоставление прав доступа к заметке новому пользователю.
        /// </summary>
        /// <param name="changeUserId">Id пользователя, который предоставляет.</param>
        /// <param name="userId">Id нового пользователя.</param>
        /// <param name="noteId">Id заметки.</param>
        /// <param name="userRights">Права доступа.</param>
        /// <returns>Новый пользователь.</returns>
        NoteAccessRight CreateUserNote(String changeUserId, String userId, String noteId, UserRights userRights);
        /// <summary>
        /// Изменение прав доступа к заметке пользователю.
        /// </summary>
        /// <param name="changeUserId">Id пользователя, который меняет.</param>
        /// <param name="userId">Id изменяемого пользователя.</param>
        /// <param name="noteId">Id заметки.</param>
        /// <param name="userRights">Права доступа.</param>
        /// <returns>Измененный пользователь.</returns>
        NoteAccessRight ChangeUserNote(String changeUserId, String userId, String noteId, UserRights userRights);
        /// <summary>
        /// Удаление прав доступа к заметке пользователя.
        /// </summary>
        /// <param name="changeUserId">Id пользователя, который удаляет.</param>
        /// <param name="userId">Id удаляемого пользователя.</param>
        /// <param name="noteId">Id заметки.</param>
        /// <returns>Удаленный пользователь.</returns>
        NoteAccessRight DeleteUserNote(String changeUserId, String userId, String noteId);
        #endregion
        
        #region AvatarRepository
        /// <summary>
        /// Получение автарки по Id пользователя.
        /// </summary>
        /// <param name="userId">Id пользователя.</param>
        /// <param name="path">Путь до хранилища файлов.</param>
        /// <returns>Изображение.</returns>
        byte[] GetAvatar(string userId, string path);
        #endregion
    }
}