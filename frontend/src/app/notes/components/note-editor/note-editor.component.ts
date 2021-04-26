import { Component, Input, Output, EventEmitter } from '@angular/core';

/**
 * Компонент поля ввода текста заметки
 */
@Component({
  selector: 'isis-note-editor',
  templateUrl: './note-editor.component.html',
  styleUrls: ['./note-editor.component.css']
})
export class NoteEditorComponent {

  /**
   * Текст заметки
   */
  @Input()
  inputModel: string;

  /**
   * Отправитель событий изменения текста заметки
   */
  @Output()
  inputModelChange = new EventEmitter<string>();

  /**
   * Конструктор
   */
  constructor() { }

}
