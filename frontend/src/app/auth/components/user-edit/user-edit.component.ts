import { Component, OnInit } from '@angular/core';
import { User } from '../../../shared/models/user';
import { AuthService } from '../../services/auth.service';
import { FormControl } from '@angular/forms';
import { ApiService } from '../../../api/services/api.service';

@Component({
  selector: 'isis-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {

  public user: User = this.auth.currentSessionValue.user;
  public fullUserDataForm = new FormControl({
    login: this.user.username,
    email: this.user.email,
    password: '',
    confirmPassword: '',
  });

  public file = this.user.avatar;
  public fileBinary;

  public isChangingActive = false;

  constructor(
    public auth: AuthService,
    public api: ApiService,
  ) { }

  ngOnInit(): void {
  }

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

  public async onUpdate(): Promise<void> {
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
