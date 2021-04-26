using System;
using System.Collections.Generic;
using ISISNotesBackend.Core.Models;

namespace ISISNotesBackend.Core.Repositories
{
    public interface INoteRepository
    {
        /// <summary>
        /// Получает все заметки пользователяы.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя.</param>
        /// <returns>Заметки пользователя.</returns>
        IEnumerable<Note> GetUserNotes(Guid userId);
        /// <summary>
        /// Создает новую заметку.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, создающего заметку.</param>
        /// <param name="name">Имя заметки.</param>
        /// <returns>Созданная заметка.</returns>
        Note CreateNote(Guid userId, String name);

        /// <summary>
        /// Получает содержимое заметки.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который хочет получить содержимое заметки.</param>
        /// <param name="noteId">Идентификатор заметки.</param>
        /// <returns>Текст заметки.</returns>
        IEnumerable<INoteContent> GetNoteContent(Guid userId, Guid noteId);
        /// <summary>
        /// Изменяет текстовое содержимое заметки.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который хочет изменить содержимое заметки..</param>
        /// <param name="noteId">Идентификатор заметки.</param>
        /// <param name="noteContent">Новое содержимое заметки.</param>
        /// <returns>Текст заметки.</returns>
        NoteAllContent ChangeNoteText(Guid userId, Guid noteId, INoteContent[] noteContent);
        /// <summary>
        /// Изменяет имя заметки.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который хочет изменить имя.</param>
        /// <param name="noteId">Идентификатор заметки.</param>
        /// <param name="name">Новое имя.</param>
        /// <returns>Заметка.</returns>
        NoteAllContent ChangeNoteName(Guid userId, Guid noteId, String name);
        /// <summary>
        /// Удаляет заметку.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который хочет удалить заметку.</param>
        /// <param name="noteId">Идeнтификатор заметки.</param>
        /// <returns>Удаленная заметка.</returns>
        Note DeleteNote(Guid userId, Guid noteId);
        /// <summary>
        /// Прикрепляет файл к заметке.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который хочет добавить файл к заметке.</param>
        /// <param name="file">Файл.</param>
        /// <returns>Добавленный файл.</returns>
        NoteFileContent AddFile(Guid userId, NoteFileContent file);
        /// <summary>
        /// Получает файл по его идентификатору.
        /// </summary>
        /// <param name="userId">Идентификатор пользователя, который хочет получить файл.</param>
        /// <param name="fileId">Идентификатор файла.</param>
        /// <returns>Файл.</returns>
        NoteFileContent GetFile(Guid userId, Guid fileId);
        /// <summary>
        /// Получает файл по имени.
        /// </summary>
        /// <param name="filename">Имя файла.</param>
        /// <returns>File.</returns>
        NoteFileContent GetFileByName(String filename);
        /// <summary>
        /// Удаляет файл.
        /// </summary>
        /// <param name="userId">Идентификатор польщователя, который хочет удалить заметку.</param>
        /// <param name="fileId">Идентификатор файла.</param>
        /// <returns>Удаленный файл.</returns>
        NoteFileContent DeleteFile(Guid userId, Guid fileId);
    }
}