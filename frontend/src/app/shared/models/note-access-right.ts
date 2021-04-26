/**
 * Запись о предоставлении пользователю прав доступа к заметке
 */
export interface NoteAccessRight {
  /**
   * Id заметки
   */
  noteId: string;
  /**
   * Id пользователя, которому предоставляются права
   */
  userId: string;
  /**
   * Права доступа
   */
  rights: 'read' | 'write' | 'author';
}
