import { NoteFileContent } from './note-file-content';

/**
 * Метаданные файла, включая файл в бинарном формате
 */
export interface FileData {
  /**
   * Метаданные файла
   */
  file: NoteFileContent;
  /**
   * Файл в бинарном формате
   */
  content: Blob;
}
