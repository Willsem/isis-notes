export interface Note {
  id: string;
  name: string;
  mode: 'read' | 'write' | 'author';
}
