import { Component, Inject, OnInit } from '@angular/core';
import { User } from '../../../shared/models/user';
import { ApiService } from '../../../api/services/api.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AuthService } from '../../../auth/services/auth.service';
import { of } from 'rxjs';

/**
 * Компонент управления правами доступа
 */
@Component({
  selector: 'isis-note-grant-rights',
  templateUrl: './note-grant-rights.component.html',
  styleUrls: ['./note-grant-rights.component.css']
})
export class NoteGrantRightsComponent implements OnInit {

  /**
   * Список пользователей
   */
  public users: { user: User, rights: 'read' | 'write' | 'author' | '' }[] = [];
    // [
    //   {
    //     user: {
    //       id: '',
    //       email: 'kdkdkkdkdkd',
    //       username: 'keker',
    //       avatar: ''
    //     },
    //     rights: 'read',
    //   },
    //   {
    //     user: {
    //       id: '',
    //       email: 'erereererer',
    //       username: 'loler',
    //       avatar: ''
    //     },
    //     rights: 'write',
    //   }
    // ];

  /**
   * Конструктор
   *
   * @param api Сервис API
   * @param auth Сервис авторизации
   * @param noteId Id заметки, передаваемое в диалог
   */
  constructor(
    public api: ApiService,
    public auth: AuthService,
    @Inject(MAT_DIALOG_DATA) public noteId: string,
  ) { }

  /**
   * Обработчик событий инициализации компонента
   */
  ngOnInit(): void {
    this.api.getUsers().subscribe(users => {
      this.users = users.map(u => ({user: u, rights: ''}));

      this.users.forEach(async u => {
        const userNotes = (await this.api.getUserNotes(u.user.id).toPromise()); // TODO: create route for getting rights

        u.rights = userNotes[userNotes.map(n => n.id).indexOf(this.noteId)].mode || '';
      });
    });
  }

  /**
   * Добавить права пользователю
   *
   * @param user Объект пользователя
   * @param rights Права пользователя
   */
  public async addRights(user: User, rights: 'read' | 'write'): Promise<void> {
    const userNotes = (await this.api.getUserNotes(user.id).toPromise()).map(n => n.id); // TODO: create route for getting rights

    if (userNotes.includes(this.noteId)) {
      await this.api.editPermissionsToUser(
        this.auth.currentSessionValue.user.id,
        this.noteId,
        { userId: user.id, noteId: this.noteId, rights }
      ).toPromise();
    } else {
      await this.api.addPermissionsToUser(
        this.auth.currentSessionValue.user.id,
        this.noteId,
        { userId: user.id, noteId: this.noteId, rights }
      ).toPromise();
    }
  }

  /**
   * Отобрать права у пользователя
   *
   * @param user Объект пользователя
   */
  public async revokeRights(user: User): Promise<void> {
    await this.api.removeUserPermissions(this.auth.currentSessionValue.user.id, this.noteId, user.id).toPromise();
  }
}
