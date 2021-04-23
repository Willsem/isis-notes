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

  constructor(
    public auth: AuthService,
    public api: ApiService,
  ) { }

  ngOnInit(): void {
  }

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

  onUpdate(): void {
    console.log('Update');
  }
}
