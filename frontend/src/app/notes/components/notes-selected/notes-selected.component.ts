import { Component, OnInit } from '@angular/core';
import { Note } from '../../../shared/models/note';
import { ActivatedRoute } from '@angular/router';
import { NotesService } from '../../services/notes.service';
import * as moment from 'moment';

/**
 * Компонент отображения выбранной заметки
 */
@Component({
  selector: 'isis-notes-selected',
  templateUrl: './notes-selected.component.html',
  styleUrls: ['./notes-selected.component.css']
})
export class NotesSelectedComponent implements OnInit {

  /**
   * Время последней синхронизации заметки
   */
  public syncTime = moment(Date.now()).toDate();

  /**
   * Данные заметки
   */
  public note: Note = {id: '', mode: 'read', name: ''};

  /**
   * Проверка прав пользователя на запись
   */
  public isWriter = this.note.mode === 'author' || this.note.mode === 'write';
  /**
   * Проверка авторства пользователя
   */
  public isAuthor = this.note.mode === 'author';

  /**
   * tmp
   */
  public content1: string = '';

  /**
   * Конструктор
   *
   * @param notes Сервис заметок
   * @param route Сервис управления текущим путем
   */
  constructor(
    public notes: NotesService,
    public route: ActivatedRoute,
  ) { }

  /**
   * Обработчик событий инициализации компонента
   */
  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.note = this.notes.getNoteById(params.get('id'));
      this.isWriter = this.note.mode === 'author' || this.note.mode === 'write';
      this.isAuthor = this.note.mode === 'author';
    });
  }

}
