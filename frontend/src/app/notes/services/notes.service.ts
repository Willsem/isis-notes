import { Injectable } from '@angular/core';
import { ApiService } from '../../api/services/api.service';
import { BehaviorSubject } from 'rxjs';
import { Note } from '../../shared/models/note';
import { AuthService } from '../../auth/services/auth.service';
import { NoteContent } from '../../shared/models/note-content';
import {NoteData} from '../../shared/models/note-data';

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

  public getNoteById(noteId): Note {
    const index = this.notes.value.map(n => n.id).indexOf(noteId);

    return this.notes.value[index];
  }

  public async getNoteContent(noteId: string): Promise<NoteContent[]> {
    return this.api.getNoteContent(this.auth.currentSessionValue.user.id, noteId).toPromise();
  }

  public async createNewNote(): Promise<Note> {
    let newNote = {
      id: '',
      mode: 'author',
      name: 'Unnamed note',
    } as Note;

    newNote = await this.api.createNote(this.auth.currentSessionValue.user.id, newNote).toPromise();

    const allNotes = this.notes.value;
    allNotes.push(newNote);
    this.notes.next(allNotes);

    return newNote;
  }

  public async editNoteContent(noteData: NoteData): Promise<NoteData> {
    return this.api.editNoteContent(this.auth.currentSessionValue.user.id, noteData).toPromise();
  }

  public async deleteNote(noteId: string): Promise<void> {
    const deletedNote = await this.api.deleteNote(this.auth.currentSessionValue.user.id, noteId).toPromise();

    let notes = this.notes.value;
    notes = notes.splice(notes.findIndex(n => n.id === deletedNote.id), 1);
    this.notes.next(notes);
  }
}
