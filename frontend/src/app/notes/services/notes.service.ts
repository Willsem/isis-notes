import { Injectable } from '@angular/core';
import { ApiService } from '../../api/services/api.service';
import { BehaviorSubject } from 'rxjs';
import { Note } from '../../shared/models/note';
import { AuthService } from '../../auth/services/auth.service';
import { NoteContent } from '../../shared/models/note-content';

/**
 * Сервис управления заметками текущего пользователя
 */
@Injectable({
  providedIn: 'root'
})
export class NotesService {

  /**
   * Полный список заметок
   * @private
   */
  private notes = new BehaviorSubject<Note[]>([]);

  /**
   * Объект асинхронного предоставления полного списка заметок
   */
  public notesObservable = this.notes.asObservable();

  /**
   * Конструктор
   *
   * @param api Сервис API
   * @param auth Сервис авторизации
   */
  constructor(
    private api: ApiService,
    private auth: AuthService,
  ) {
    this.auth.onSessionRenew.subscribe(async session => {
      if (session) {
        await this.loadNotes();
      } else {
        this.notes.next([]);
      }
    });
    this.loadNotes(); // TODO: remove
  }

  /**
   * Загрузить список заметок пользователя
   */
  public async loadNotes(): Promise<void> {
    const notes = [ // TODO: remove
      {
        id: 'asd',
        name: 'KEK',
        mode: 'author'
      },
      {
        id: 'qwe',
        name: 'LOL',
        mode: 'write'
      },
      {
        id: 'zxc',
        name: 'BOGOMOL',
        mode: 'read'
      }
    ] as Note[]; // await this.api.getUserNotes(this.auth.currentSessionValue.user.id).toPromise();

    this.notes.next(notes);
  }

  /**
   * Получить заметку из списка по id
   *
   * @param noteId Id заметки
   */
  public getNoteById(noteId): Note {
    const index = this.notes.value.map(n => n.id).indexOf(noteId);

    return this.notes.value[index];
  }

  /**
   * Получить все фрагменты заметки
   *
   * @param noteId Id заметки
   */
  public async getNoteContent(noteId: string): Promise<NoteContent[]> {
    return this.api.getNoteContent(this.auth.currentSessionValue.user.id, noteId).toPromise();
  }
}
