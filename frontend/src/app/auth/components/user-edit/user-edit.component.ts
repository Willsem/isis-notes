import { Component, OnInit } from '@angular/core';
import { User } from '../../../shared/models/user';
import { AuthService } from '../../services/auth.service';
import { FormControl } from '@angular/forms';
import { ApiService } from '../../../api/services/api.service';

/**
 * Компонент редактирования информации о пользователе
 */
@Component({
  selector: 'isis-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent {

  /**
   * Данные пользователя
   */
  public user: User = this.auth.currentSessionValue.user;
  /**
   * Контроллер формы ввода данных пользователя
   */
  public fullUserDataForm = new FormControl({
    login: this.user.username,
    email: this.user.email,
    password: '',
    confirmPassword: '',
  });

  /**
   * Аватар пользователя в формате base64
   */
  public file = this.user.avatar;
  /**
   * Аватар пользователя в бинарном формате
   */
  public fileBinary;

  /**
   * Конструктор
   *
   * @param auth Сервис авторизации
   * @param api Сервис API
   */
  constructor(
    public auth: AuthService,
    public api: ApiService,
  ) { }

  /**
   * Обработчик загрузки нового аватара
   *
   * @param event Событие загрузки файла
   */
  onAvatarChange(event: Event): void {
    console.log(event);
    const file = (event.target as HTMLInputElement).files[0];
    const fileReader = new FileReader();
    fileReader.onloadend = (e) => {
      this.file = fileReader.result as string;
      console.log(this.file);
    };
    file.arrayBuffer().then(buf => this.fileBinary = new Blob([buf]));
    fileReader.readAsDataURL(file);
  }

  /**
   * Обработчик события обновления данных о пользователе
   */
  onUpdate(): void {
    console.log('Update');
  }
}
