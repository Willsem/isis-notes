import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanActivateChild } from '@angular/router';
import { AuthService } from '../services/auth.service';

/**
 * Guard для путей, предполагающих авторизацию
 */
@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild {

  /**
   * Конструктор
   *
   * @param auth Сервис авторизации
   * @param router Сервис Ангуляра для роутинга
   */
  constructor(
    private auth: AuthService,
    private router: Router,
  ) { }

  /**
   * Проверка возможности активации дочерних путей
   */
  public canActivateChild = this.canActivate;

  /**
   * Проверка возможности активации пути
   *
   * @param route Текущий путь
   * @param state Состояние роутинга
   */
  public canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean | UrlTree {
    return this.auth.isAuthed ? true : this.router.parseUrl(`/auth/sign-in?redirect=${state.url}`);
  }
}
