import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../../api/services/api.service';
import {Router} from '@angular/router';
import {AbstractControl, FormControl, ValidatorFn} from '@angular/forms';

@Component({
  selector: 'isis-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {

  userRegisterDataForm = new FormControl({
    login: '',
    email: '',
    password: '',
    confirmPassword: ''
  }, [this.validatePassword()]);

  constructor(
    public api: ApiService,
    public router: Router,
  ) { }

  ngOnInit(): void {
  }

  public validatePassword(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      return control.value.password === control.value.confirmPassword && control.value !== ''
        ? null : {'Passwords must match': true};
    };
  }

  public async onRegister(): Promise<void> {
    if (this.userRegisterDataForm.value.email === '' || this.userRegisterDataForm.value.login === ''
      || this.userRegisterDataForm.value.password === '' || this.userRegisterDataForm.value.confirmPassword === ''
      || this.userRegisterDataForm.invalid) {
      console.log(this.userRegisterDataForm.errors); // TODO: Add error handling
      return;
    }

    await this.api.registerUser({
      user: {
        username: this.userRegisterDataForm.value.login,
        email: this.userRegisterDataForm.value.email,
        id: '',
        avatar: ''
      },
      login: {
        username: this.userRegisterDataForm.value.login,
        password: this.userRegisterDataForm.value.password,
      }
    }).toPromise();

    await this.router.navigateByUrl('/auth/sign-in');
  }

}
