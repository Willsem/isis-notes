import { Note } from './note';
import { NoteContent } from './note-content';

/**
 * Полные данные заметки
 */
export interface NoteData {
  /**
   * Метаданные заметки
   */
  note: Note;
  /**
   * Фрагменты содержимого заметки
   */
  content: NoteContent[];
}
