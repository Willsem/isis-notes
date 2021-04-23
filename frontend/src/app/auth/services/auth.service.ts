import { Injectable } from '@angular/core';
import { BehaviorSubject, fromEvent } from 'rxjs';
import { Session } from '../../shared/models/session';
import { Login } from '../../shared/models/login';
import { ApiService } from '../../api/services/api.service';
import { map } from 'rxjs/operators';
import * as moment from 'moment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private readonly SESSION_STORAGE_KEY = 'isisCurrentSession';

  private currentSession = new BehaviorSubject<Session | null>(null);
  public currentSessionObservable = this.currentSession.asObservable();

  private jwtToken = '';
  private sessionChannel = new BroadcastChannel('auth');

  public onSessionRenew = fromEvent<MessageEvent>(this.sessionChannel, 'message').pipe(
    map(msg => JSON.parse(msg.data) as Session | null)
  );


  public get jwtTokenValue(): string {
    return this.jwtToken;
  }

  public get isAuthed(): boolean {
    return !!this.currentSession.value;
  }

  public get currentSessionValue(): Session | null {
    return this.currentSession.value;
  }

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

  public async login(login: Login): Promise<Session> {
    const session = await this.api.createSession(login).toPromise();

    this.currentSession.next(session);
    this.jwtToken = session.token;
    this.sessionChannel.postMessage(JSON.stringify(session));
    localStorage.setItem(this.SESSION_STORAGE_KEY, JSON.stringify(session));

    return session;
  }

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
