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
export class UserEditComponent implements OnInit {

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
   * Флаг подгрузки изображения аватара
   */
  public isChangingActive = false;

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
   * Обработчик событий инициализации компонента
   */
  ngOnInit(): void {
    this.api.getUserAvatar(this.user.id).subscribe(blob => {
      this.fileBinary = blob;

      const fileReader = new FileReader();

      fileReader.onloadend = (e) => {
        this.file = this.user.avatar = fileReader.result as string;
      };

      fileReader.readAsDataURL(blob);
    });
  }

  /**
   * Обработчик загрузки нового аватара
   *
   * @param event Событие загрузки файла
   */
  onAvatarChange(event: Event): void {
    this.isChangingActive = true;

    const file = (event.target as HTMLInputElement).files[0];
    const fileReader = new FileReader();

    fileReader.onloadend = (e) => {
      this.file = fileReader.result as string;
    };

    file.arrayBuffer().then(buf => {
      this.fileBinary = new Blob([buf]);
      this.isChangingActive = false;
    });

    fileReader.readAsDataURL(file);
  }

  /**
   * Обработчик события обновления данных о пользователе
   */
  public async onUpdate(): Promise<void> {
    if (this.fullUserDataForm.invalid) {
      return;
    }

    const newUser = await this.api.editUser({
      user: {
        id: this.user.id,
        email: this.fullUserDataForm.value.email,
        username: this.fullUserDataForm.value.login,
        avatar: '',
      },
      login: {
        username: this.fullUserDataForm.value.login,
        password: this.fullUserDataForm.value.password,
      }
    }, this.fileBinary).toPromise();

    await this.auth.logout();
    await this.auth.login({ username: newUser.username, password: this.fullUserDataForm.value.password });
  }
}
