import { Component, Input, Output, EventEmitter } from '@angular/core';

/**
 * Компонент текстового фрагмента заметки
 */
@Component({
  selector: 'isis-note-content',
  templateUrl: './note-content.component.html',
  styleUrls: ['./note-content.component.css']
})
export class NoteContentComponent {

  /**
   * Конструктор
   */
  constructor() { }

  /**
   * Текст заметки
   */
  public contentFromEditor: string = '';

  /**
   * Права доступа пользователя
   */
  @Input()
  public mode: 'read' | 'write' | 'author' = 'read';

  /**
   * Установка значения текста заметки
   *
   * @param content Текст заметки
   */
  @Input()
  set value(content: string) {
    this.contentFromEditor = content;
  }

  /**
   * Отправитель событий изменения текста заметки
   */
  @Output()
  valueChange = new EventEmitter<string>();

}
