import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../../auth/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'isis-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {

  constructor(
    public auth: AuthService,
    public router: Router,
  ) { }

  ngOnInit(): void {
  }

  public async onLogout(): Promise<void> {
    await this.auth.logout();

    await this.router.navigateByUrl('/auth/sign-in');
  }
}
