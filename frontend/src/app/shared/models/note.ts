/**
 * Метаданные заметки
 */
export interface Note {
  /**
   * id заметки
   */
  id: string;
  /**
   * Заголовок заметки
   */
  name: string;
  /**
   * Права доступа пользователя к заметке
   */
  mode: 'read' | 'write' | 'author';
}
