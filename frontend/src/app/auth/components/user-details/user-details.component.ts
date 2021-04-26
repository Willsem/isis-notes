import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { User } from '../../../shared/models/user';
import { MatDialog } from '@angular/material/dialog';
import { UserEditComponent } from '../user-edit/user-edit.component';
import { ApiService } from '../../../api/services/api.service';

/**
 * Компонент отображения данных пользователя
 */
@Component({
  selector: 'isis-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  /**
   * Данные пользователя
   */
  public user: User;

  /**
   * Конструктор
   *
   * @param auth Сервис авторизации
   * @param dialog Контроллер диалогов Material
   * @param api Сервис API
   */
  constructor(
    public auth: AuthService,
    public dialog: MatDialog,
    public api: ApiService,
  ) { }

  /**
   * Обработчик событий инициализации компонента
   */
  ngOnInit(): void {
    this.user = this.auth.currentSessionValue.user ?? {id: '', username: '', email: '', avatar: ''};

    this.api.getUserAvatar(this.user.id).subscribe(blob => {
      const fileReader = new FileReader();

      fileReader.onloadend = (e) => {
        this.user.avatar = fileReader.result as string;
      };

      fileReader.readAsDataURL(blob);
    });
  }

  /**
   * Обработчик открытия диалога редактирования пользователя
   */
  public onEditUser(): void {
    this.dialog.open(UserEditComponent, { disableClose: true }).afterClosed().subscribe(() => {
      this.ngOnInit();
    });
  }

}
