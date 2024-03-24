import { Component, OnInit } from '@angular/core';
import { UserPersonalInfo } from 'src/app/model/personal-info-model';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-host-dashboard',
  templateUrl: './host-dashboard.component.html',
  styleUrls: ['./host-dashboard.component.css']
})
export class HostDashboardComponent implements OnInit {

  userPersonalInfo: UserPersonalInfo = new UserPersonalInfo();
  activeTab: string = 'PERSONAL_INFO';

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.userService.getCurrentUserInfo().subscribe((data: UserPersonalInfo) => {
      this.userPersonalInfo = data;
      console.log(data);
    });
  }

  changeTab(tabName: string) {
    this.activeTab = tabName;
  }

}
