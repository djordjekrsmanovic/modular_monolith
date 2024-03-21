import { Component, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';
import { UserModel } from 'src/app/model/user-model';
import { ClientService } from 'src/app/service/guest.service';
import { UserHeaderComponent } from '../../header/user-header/user-header.component';

@Component({
  selector: 'app-guest-dashboard',
  templateUrl: './guest-dashboard.component.html',
  styleUrls: ['./guest-dashboard.component.css'],
})
export class GuestDashboardComponent implements OnInit {
  client: Guest = new Guest();
  activeTab: string = 'PERSONAL_INFO';

  constructor(private clientService: ClientService) {}

  ngOnInit(): void {
    this.clientService.getCurrentClient().subscribe((data: Guest) => {
      this.client = data;
      console.log(data);
    });
  }

  changeTab(tabName: string) {
    this.activeTab = tabName;
  }
}
