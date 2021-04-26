import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';

@Injectable()
export class JwtTokenInterceptor implements HttpInterceptor {

  constructor(
    private auth: AuthService,
  ) { }

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
