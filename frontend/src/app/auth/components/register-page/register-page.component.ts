import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../api/services/api.service';
import {Router} from '@angular/router';

@Component({
  selector: 'isis-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {

  userRegisterData = {
    login: '',
    email: '',
    password: '',
    confirmPassword: ''
  };

  constructor(
    public api: ApiService,
    public router: Router,
  ) { }

  ngOnInit(): void {
  }

  public async onRegister(): Promise<void> {
    console.log({
      user: {
        username: this.userRegisterData.login,
        email: this.userRegisterData.email,
        id: '',
        avatar: ''
      },
      login: {
        username: this.userRegisterData.login,
        password: this.userRegisterData.password,
      }
    });
    await this.api.registerUser({
      user: {
        username: this.userRegisterData.login,
        email: this.userRegisterData.email,
        id: '',
        avatar: ''
      },
      login: {
        username: this.userRegisterData.login,
        password: this.userRegisterData.password,
      }
    }).toPromise();

    await this.router.navigateByUrl('/auth/sign-in');
  }

}
