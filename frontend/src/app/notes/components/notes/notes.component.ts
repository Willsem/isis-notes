import { Component } from '@angular/core';
import { AuthService } from '../../../auth/services/auth.service';
import { Router } from '@angular/router';

/**
 * Компонент-контейнер для отображения заметок
 */
@Component({
  selector: 'isis-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent {

  /**
   * Конструктор
   *
   * @param auth Сервис авторизации
   * @param router Сервис Ангуляра для роутинга
   */
  constructor(
    public auth: AuthService,
    public router: Router,
  ) { }

  /**
   * Обработчик выхода пользователя из сессии
   */
  public async onLogout(): Promise<void> {
    await this.auth.logout();

    await this.router.navigateByUrl('/auth/sign-in');
  }
}
