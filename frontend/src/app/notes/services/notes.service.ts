import { Injectable } from '@angular/core';
import { ApiService } from '../../api/services/api.service';
import {BehaviorSubject, of} from 'rxjs';
import { Note } from '../../shared/models/note';
import { AuthService } from '../../auth/services/auth.service';
import {NoteContent} from '../../shared/models/note-content';

@Injectable({
  providedIn: 'root'
})
export class NotesService {
  private notes = new BehaviorSubject<Note[]>([]);

  public notesObservable = this.notes.asObservable();

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

  public async getNoteContent(noteId: string): Promise<NoteContent[]> {
    return this.api.getNoteContent(this.auth.currentSessionValue.user.id, noteId).toPromise();
  }
}
