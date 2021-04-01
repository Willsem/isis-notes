import { NoteContent } from './note-content';

export interface NoteFileContent extends NoteContent {
  fileName: string;
  fileType: string;
  fileId: string;
}
