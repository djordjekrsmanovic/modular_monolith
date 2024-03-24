import { Component, OnInit } from '@angular/core';
import { ActiveUser } from 'src/app/model/user-model';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'user-header',
  templateUrl: './user-header.component.html',
  styleUrls: ['./user-header.component.css'],
})
export class UserHeaderComponent implements OnInit {
  user = new ActiveUser();
  db_url = '/';

  constructor(private loginService: UserService) {}

  ngOnInit(): void {
    let currentUser: ActiveUser = JSON.parse(
      localStorage.getItem('currentUser')!
    );
    if (currentUser.role != 'LOGGED_OUT' && currentUser != null) {
      this.user = currentUser;
      switch (this.user.role) {
        case 'Guest':
          this.db_url = '/guest-db';
          break;
        case 'Host':
          this.db_url = '/host-db';
          break;
      }
    }
  }

  logOut() {
    this.loginService.logout();
  }
}
