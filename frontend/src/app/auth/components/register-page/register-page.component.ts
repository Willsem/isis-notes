import { Component } from '@angular/core';
import { ApiService } from '../../../api/services/api.service';
import { Router } from '@angular/router';
import { AbstractControl, FormControl, ValidatorFn } from '@angular/forms';

/**
 * Компонент регистрации нового пользователя
 */
@Component({
  selector: 'isis-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent {

  /**
   * Контроллер формы ввода данных пользователя
   */
  userRegisterDataForm = new FormControl({
    login: '',
    email: '',
    password: '',
    confirmPassword: ''
  }, [this.validatePassword()]);

  /**
   * Конструктор
   *
   * @param api Сервис API
   * @param router Сервис Ангуляра для роутинга
   */
  constructor(
    public api: ApiService,
    public router: Router,
  ) { }

  /**
   * Валидация равенства паролей, введенных в оба поля
   */
  public validatePassword(): ValidatorFn {
    return (control: AbstractControl): { [key: string]: boolean } | null => {
      return control.value.password === control.value.confirmPassword
        ? null : {'Passwords must match': true};
    };
  }

  /**
   * Обработчик регистрации нового пользователя
   */
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
