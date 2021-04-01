export interface NoteAccessRight {
  noteId: string;
  userId: string;
  rights: 'read' | 'write' | 'author';
}
