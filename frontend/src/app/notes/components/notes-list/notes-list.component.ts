import { Component, OnInit } from '@angular/core';
import { NotesService } from '../../services/notes.service';
import { Router } from '@angular/router';

/**
 * Компонент списка заметок
 */
@Component({
  selector: 'isis-notes-list',
  templateUrl: './notes-list.component.html',
  styleUrls: ['./notes-list.component.css']
})
export class NotesListComponent {

  /**
   * Конструктор
   *
   * @param notes Сервис заметок
   * @param router Сервис Ангуляра для роутинга
   */
  constructor(
    public notes: NotesService,
    public router: Router,
  ) {
    this.notes.notesObservable.subscribe(console.log);
  }

  /**
   * Обработчик перехода к отображению заметки
   *
   * @param id Id заметки
   */
  public async navigate(id: string): Promise<void> {
    await this.router.navigateByUrl('/notes/' + id);
  }

  public async onNewNote(): Promise<void> {
    const newNote = await this.notes.createNewNote();
    await this.navigate(newNote.id);
  }
}
