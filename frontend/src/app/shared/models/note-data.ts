import { Note } from './note';
import { NoteContent } from './note-content';

export interface NoteData {
  note: Note;
  content: NoteContent[];
}
