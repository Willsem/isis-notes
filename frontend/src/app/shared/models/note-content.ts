/**
 * Фрагмент содержимого заметки
 */
export interface NoteContent {
  /**
   * Id заметки
   */
  noteId: string;
  /**
   * Тип фрагмента содержимого
   */
  type: 'text' | 'file';
}
