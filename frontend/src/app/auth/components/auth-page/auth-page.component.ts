import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-auth-page',
  templateUrl: './auth-page.component.html',
  styleUrls: ['./auth-page.component.css']
})
export class AuthPageComponent implements OnInit {
  public username = '';
  public password = '';

  constructor(
    public router: Router,
    public auth: AuthService,
    public route: ActivatedRoute,
  ) { }

  ngOnInit(): void {
  }

  public async onLogin(): Promise<void> {
    const session = await this.auth.login({
      username: this.username,
      password: this.password,
    });

    if (session) {
      await this.redirectAfterLogin();
    }
  }

  public onClear(): void {
    this.username = '';
    this.password = '';
  }

  public async redirectAfterLogin(): Promise<void> {
    const redirect = this.route.snapshot.queryParamMap.get('redirect') || '/';
    await this.router.navigateByUrl(redirect);
  }

  public onForgot(): void {

  }
}
