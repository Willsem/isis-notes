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

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  public getUserNotes(userId: string): Observable<Note[]> {
    const url = `${environment.backendUrl}/notes/${userId}`;
    return this.http.get<Note[]>(url);
  }

  public createNote(userId: string, note: Note): Observable<Note> {
    const url = `${environment.backendUrl}/notes/${userId}`;
    return this.http.post<Note>(url, note);
  }

  public getNoteContent(userId: string, noteId: string): Observable<NoteContent[]> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}`;
    return this.http.get<NoteContent[]>(url);
  }

  public editNoteContent(userId: string, noteData: NoteData): Observable<NoteData> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteData.note.id}`;
    return this.http.patch<NoteData>(url, noteData);
  }

  public deleteNote(userId: string, noteId: string): Observable<Note> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}`;
    return this.http.delete<Note>(url);
  }

  public addFile(userId: string, fileData: FileData): Observable<NoteFileContent> {
    const url = `${environment.backendUrl}/file/${userId}`;
    return this.http.post<NoteFileContent>(url, fileData);
  }

  public getFile(userId: string, fileId: string): Observable<Blob> {
    const url = `${environment.backendUrl}/file/${userId}/${fileId}`;
    return this.http.get<Blob>(url);
  }

  public deleteFile(userId: string, fileId: string): Observable<NoteFileContent> {
    const url = `${environment.backendUrl}/file/${userId}/${fileId}`;
    return this.http.delete<NoteFileContent>(url);
  }

  public createSession(login: Login): Observable<Session> {
    const url = `${environment.backendUrl}/session`;
    return this.http.post<Session>(url, login);
  }

  public deleteSession(sessionId: string): Observable<Session> {
    const url = `${environment.backendUrl}/session/${sessionId}`;
    return this.http.delete<Session>(url);
  }

  public getUsers(): Observable<User[]> {
    const url = `${environment.backendUrl}/users`;
    return this.http.get<User[]>(url);
  }

  public registerUser(userLogin: UserLogin): Observable<User> {
    const url = `${environment.backendUrl}/users`;
    return this.http.post<User>(url, userLogin);
  }

  public editUser(userLogin: UserLogin, avatarBinary?: Blob): Observable<User> {
    const url = `${environment.backendUrl}/users`;
    return this.http.patch<User>(url, {
      user: userLogin.user,
      login: userLogin.login,
      avatar_content: avatarBinary,
    });
  }

  public addPermissionsToUser(userId: string, noteId: string, noteAccessRight: NoteAccessRight): Observable<NoteAccessRight> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}/permission`;
    return this.http.post<NoteAccessRight>(url, noteAccessRight);
  }

  public editPermissionsToUser(userId: string, noteId: string, noteAccessRight: NoteAccessRight): Observable<NoteAccessRight> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}/permission`;
    return this.http.patch<NoteAccessRight>(url, noteAccessRight);
  }

  public removeUserPermissions(userId: string, noteId: string, toUserId: string): Observable<NoteAccessRight> {
    const url = `${environment.backendUrl}/notes/${userId}/${noteId}/permission/${toUserId}`;
    return this.http.delete<NoteAccessRight>(url);
  }
}
