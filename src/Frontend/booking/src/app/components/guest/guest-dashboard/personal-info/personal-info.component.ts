import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';
import { UserPersonalInfo } from 'src/app/model/personal-info-model';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-personal-info',
  templateUrl: './personal-info.component.html',
  styleUrls: ['./personal-info.component.css'],
})
export class PersonalInfoComponent implements OnInit {
  @Input() client = new UserPersonalInfo();

  constructor(private userService:UserService) {}

  ngOnInit(): void {
    this.userService.getCurrentUserInfo().subscribe(data=>{
      this.client=data
    });
  }
}
