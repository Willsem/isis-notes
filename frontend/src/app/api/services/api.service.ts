import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Note } from '../../shared/models/note';
import { environment } from '../../../environments/environment';
import { NoteContent } from '../../shared/models/note-content';
import { NoteData } from '../../shared/models/note-data';
import { NoteFileContent } from '../../shared/models/note-file-content';
import { FileData } from '../../shared/models/file-data';
import { Login } from '../../shared/models/login';
import { Session } from '../../shared/models/session';
import { User } from '../../shared/models/user';
import { UserLogin } from '../../shared/models/user-login';
import { NoteAccessRight } from '../../shared/models/note-access-right';

/**
 * Сервис, предоставляющий методы для взаимодействия с сервером по REST API
 */
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  /**
   * Конструктор
   * @param http HTTP клиент Ангуляра
   */
  constructor(
    private http: HttpClient
  ) { }

  /**
   * Получить все заметки, к которым есть доступ у пользователя
   *
   * @param userId Id пользователя
   */
  public getUserNotes(userId: string): Observable<Note[]> {
    const url = `${environment.backendUrl}/notes/${userId}`;
    return this.http.get<Note[]>(url);
  }

  /**
   * Создать новую заметку
   *
   * @param userId Id пользователя
   * @param note Метаданные заметки
   */
  public createNote(userId: string, note: Note): Observable<Note> {
    const url = `${environment.backendUrl}/notes/${userId}`;
    return this.http.post<Note>(url, note);
  }

  /**
   * Получить все фрагменты заметки
   *
   * @param userId Id пользователя
   * @param noteId Id заметки
   */
  public getNoteContent(userId: string, noteId: string): Observable<NoteContent[]> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}`;
    return this.http.get<NoteContent[]>(url);
  }

  /**
   * Отредактировать фрагменты содержимого заметки
   *
   * @param userId Id пользователя
   * @param noteData Полные данные заметки
   */
  public editNoteContent(userId: string, noteData: NoteData): Observable<NoteData> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteData.note.id}`;
    return this.http.patch<NoteData>(url, noteData);
  }

  /**
   * Удалить заметку
   *
   * @param userId Id пользователя
   * @param noteId Id заметки
   */
  public deleteNote(userId: string, noteId: string): Observable<Note> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}`;
    return this.http.delete<Note>(url);
  }
  /**
   * Загрузить файл на сервер
   *
   * @param userId Id пользователя
   * @param fileData Полные данные файла
   */
  public addFile(userId: string, fileData: FileData): Observable<NoteFileContent> {
    const url = `${environment.backendUrl}/file/${userId}`;
    return this.http.post<NoteFileContent>(url, fileData);
  }

  /**
   * Получить файл в бинарном формате
   * @param userId Id пользователя
   * @param fileId Id файла
   */
  public getFile(userId: string, fileId: string): Observable<Blob> {
    const url = `${environment.backendUrl}/file/${userId}/${fileId}`;
    return this.http.get<Blob>(url);
  }

  /**
   * Удалить файл
   *
   * @param userId Id пользователя
   * @param fileId Id файла
   */
  public deleteFile(userId: string, fileId: string): Observable<NoteFileContent> {
    const url = `${environment.backendUrl}/file/${userId}/${fileId}`;
    return this.http.delete<NoteFileContent>(url);
  }

  /**
   * Создать новую сессию для данного пользователя
   *
   * @param login Параметры пользователя для авторизации
   */
  public createSession(login: Login): Observable<Session> {
    const url = `${environment.backendUrl}/session`;
    return this.http.post<Session>(url, login);
  }

  /**
   * Удалить сессию для текущего пользователя
   *
   * @param sessionId Id сессии
   */
  public deleteSession(sessionId: string): Observable<Session> {
    const url = `${environment.backendUrl}/session/${sessionId}`;
    return this.http.delete<Session>(url);
  }

  /**
   * Получить список всех пользователей
   */
  public getUsers(): Observable<User[]> {
    const url = `${environment.backendUrl}/users`;
    return this.http.get<User[]>(url);
  }

  /**
   * Зарегистрировать нового пользователя
   *
   * @param userLogin Полные данные пользователя
   */
  public registerUser(userLogin: UserLogin): Observable<User> {
    const url = `${environment.backendUrl}/users`;
    return this.http.post<User>(url, userLogin);
  }

  /**
   * Отредактировать пользователя
   *
   * @param userLogin Полные данные пользователя
   */
  public editUser(userLogin: UserLogin, avatarBinary?: Blob): Observable<User> {
    const url = `${environment.backendUrl}/users`;
    return this.http.patch<User>(url, {
      user: userLogin.user,
      login: userLogin.login,
      avatar_content: avatarBinary,
    });
  }

  /**
   * Дать пользователю доступ к заметке
   *
   * @param userId Id пользователя-владельца заметки
   * @param noteId Id заметки
   * @param noteAccessRight Данные для предоставления доступа
   */
  public addPermissionsToUser(userId: string, noteId: string, noteAccessRight: NoteAccessRight): Observable<NoteAccessRight> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}/permission`;
    return this.http.post<NoteAccessRight>(url, noteAccessRight);
  }

  /**
   * Отредактировать права доступа пользователя к заметке
   *
   * @param userId Id пользователя-владельца заметки
   * @param noteId Id заметки
   * @param noteAccessRight Данные для предоставления доступа
   */
  public editPermissionsToUser(userId: string, noteId: string, noteAccessRight: NoteAccessRight): Observable<NoteAccessRight> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}/permission`;
    return this.http.patch<NoteAccessRight>(url, noteAccessRight);
  }

  /**
   * Отобрать у пользователя права доступа к заметке
   *
   * @param userId Id пользователя-владельца заметки
   * @param noteId Id заметки
   * @param toUserId Данные для предоставления доступа
   */
  public removeUserPermissions(userId: string, noteId: string, toUserId: string): Observable<NoteAccessRight> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}/permission/${toUserId}`;
    return this.http.delete<NoteAccessRight>(url);
  }

  /**
   * Получить файл аватара пользователя
   *
   * @param userId Id пользователя
   */
  public getUserAvatar(userId: string): Observable<Blob> {
    const url = `${environment.backendUrl}/avatar/${userId}`;
    return this.http.get<Blob>(url);
  }
}
