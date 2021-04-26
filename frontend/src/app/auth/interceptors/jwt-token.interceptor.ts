import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

/**
 * Интерсептор для подстановки JWT токена в заголовки запросов
 */
@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor {

  /**
   * Конструктор
   *
   * @param auth Сервис авторизации
   */
  constructor(
    private auth: AuthService,
  ) { }

  /**
   * Обработчик перехвата запроса
   *
   * @param request Перехваченный запрос
   * @param next Обработчик дальнейшего пути запроса
   */
  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const isAuthed = this.auth.isAuthed;

    if (isAuthed) {
      request = request.clone({
        setHeaders: {
          'Access-Control-Allow-Origin': '*',
          'Access-Control-Allow-Methods': '*',
          Authorization: `Bearer ${this.auth.jwtTokenValue}`,
        },
        url: request.url,
      });
    }

    console.log(this.auth.jwtTokenValue);
    return next.handle(request);
  }
}
