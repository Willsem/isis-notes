import { NoteContent } from './note-content';

/**
 * Файловый фрагмент заметки
 */
export interface NoteFileContent extends NoteContent {
  /**
   * Имя файла
   */
  fileName: string;
  /**
   * MIME-тип файла
   */
  fileType: string;
  /**
   * Id файла
   */
  fileId: string;
}
