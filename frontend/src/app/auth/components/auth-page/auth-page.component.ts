import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

/**
 * Компонент авторизации
 */
@Component({
  selector: 'isis-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.css']
})
export class AuthPageComponent {
  /**
   * Имя пользователя
   */
  public username = '';
  /**
   * Пароль пользователя
   */
  public password = '';

  /**
   * Конструктор
   *
   * @param router Сервис Ангуляра для роутинга
   * @param auth Сервис авторизации
   * @param route Сервис управления текущим путем
   */
  constructor(
    public router: Router,
    public auth: AuthService,
    public route: ActivatedRoute,
  ) { }

  /**
   * Обработчик логина пользователя
   */
  public async onLogin(): Promise<void> {
    const session = await this.auth.login({
      username: this.username,
      password: this.password,
    });

    if (session) {
      await this.redirectAfterLogin();
    }
  }

  /**
   * Обработчик очистки полей ввода
   */
  public onClear(): void {
    this.username = '';
    this.password = '';
  }

  /**
   * Переадрисация пользователя после успешной авторизации
   */
  public async redirectAfterLogin(): Promise<void> {
    const redirect = this.route.snapshot.queryParamMap.get('redirect') || '/';
    await this.router.navigateByUrl(redirect);
  }

  /**
   * Обработчик восстановления пароля
   */
  public onForgot(): void {}

  /**
   * Обработчик перенаправления на страницу создания пользователя
   */
  public async onCreate(): Promise<void> {
    await this.router.navigateByUrl('/auth/register');
  }
}
