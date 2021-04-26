import { Component, Input } from '@angular/core';

/**
 * Компонент отображения текста заметки в формате markdown
 */
@Component({
  selector: 'isis-note-text',
  templateUrl: './note-text.component.html',
  styleUrls: ['./note-text.component.css']
})
export class NoteTextComponent {

  /**
   * Текст заметки
   */
  @Input()
  content: string;

  /**
   * Конструктор
   */
  constructor() { }

}
