import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { User } from '../../../shared/models/user';

@Component({
  selector: 'isis-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  public user: User;

  constructor(
    public auth: AuthService,
  ) { }

  ngOnInit(): void {
    this.user = this.auth.currentSessionValue.user ?? {id: '', username: '', email: '', avatar: ''};
  }

}
