import { Injectable } from '@angular/core';
import { BehaviorSubject, fromEvent } from 'rxjs';
import { Session } from '../../shared/models/session';
import { Login } from '../../shared/models/login';
import { ApiService } from '../../api/services/api.service';
import { map } from 'rxjs/operators';
import * as moment from 'moment';

/**
 * Сервис предоставления возможностей, связанных с авторизацией и текущим пользователем
 */
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  /**
   * Ключ для хранения текущей сессии в localStorage
   * @private
   */
  private readonly SESSION_STORAGE_KEY = 'isisCurrentSession';

  /**
   * Текущая сессия
   * @private
   */
  private currentSession = new BehaviorSubject<Session | null>(null);
  /**
   * Объект асинхронного предоставления текущей сессии
   */
  public currentSessionObservable = this.currentSession.asObservable();

  /**
   * JWT токен
   * @private
   */
  private jwtToken = '';
  /**
   * Канал передачи данных о сессии между вкладками
   * @private
   */
  private sessionChannel = new BroadcastChannel('auth');

  /**
   * Асинхронный уведомитель о событии появления новой сессии в канале {@link sessionChannel}
   */
  public onSessionRenew = fromEvent<MessageEvent>(this.sessionChannel, 'message').pipe(
    map(msg => JSON.parse(msg.data) as Session | null)
  );

  /**
   * Получить значение JWT токена
   */
  public get jwtTokenValue(): string {
    return this.jwtToken;
  }

  /**
   * Проверка авторизованности пользователя
   */
  public get isAuthed(): boolean {
    return !!this.currentSession.value;
  }

  /**
   * Получить значение текущей сессии пользователя
   */
  public get currentSessionValue(): Session | null {
    return this.currentSession.value;
  }

  /**
   * Конструктор
   *
   * @param api Сервис API
   */
  constructor(
    private api: ApiService,
  ) {
    const storedSession = {
      id: 'orpr',
      user: {
        id: 'kek',
        username: 'OverldAndrey',
        avatar: 'https://izobrazhenie.net/photo/1536-95-1/1736_609925118.jpg',
        email: 'andrey3000.99@mail.ru',
      },
      token: 'qwerty',
      timestamp: moment(Date.now()), // TODO: Remove
    } as Session; // JSON.parse(localStorage.getItem(this.SESSION_STORAGE_KEY)) as Session | null;

    if (storedSession) {
      this.currentSession.next(storedSession);
      this.jwtToken = storedSession.token;
    }

    this.onSessionRenew.subscribe(session => {
      if (session) {
        this.currentSession.next(session);
        this.jwtToken = session.token;
        localStorage.setItem(this.SESSION_STORAGE_KEY, JSON.stringify(session));
      } else {
        this.currentSession.next(null);
        this.jwtToken = '';
        localStorage.removeItem(this.SESSION_STORAGE_KEY);
      }
    });
  }

  /**
   * Обработка логина пользователя
   *
   * @param login Параметры авторизации пользователя
   */
  public async login(login: Login): Promise<Session> {
    const session = await this.api.createSession(login).toPromise();

    this.currentSession.next(session);
    this.jwtToken = session.token;
    this.sessionChannel.postMessage(JSON.stringify(session));
    localStorage.setItem(this.SESSION_STORAGE_KEY, JSON.stringify(session));

    return session;
  }

  /**
   * Обработка выхода пользователя из сеанса
   */
  public async logout(): Promise<void> {
    if (this.isAuthed) {
      await this.api.deleteSession(this.currentSession.value.id).toPromise();
    }

    this.currentSession.next(null);
    this.sessionChannel.postMessage(JSON.stringify(null));
    this.jwtToken = '';
    localStorage.removeItem(this.SESSION_STORAGE_KEY);
  }
}
