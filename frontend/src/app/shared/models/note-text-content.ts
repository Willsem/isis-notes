import { NoteContent } from './note-content';

/**
 * Текстовый фрагмент заметки
 */
export interface NoteTextContent extends NoteContent {
  /**
   * Текстовое содержимое фрагмента заметки
   */
  text: string;
}
