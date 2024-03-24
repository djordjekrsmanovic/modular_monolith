import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';
import { ChangePersonalInfo, UserPersonalInfo } from 'src/app/model/personal-info-model';
import { GuestService } from 'src/app/service/guest.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css'],
})
export class SettingsComponent implements OnInit {
  @Input() userId: string = '';
  validPassword: boolean = true;
  validForm: boolean = true;
  personalInfo:UserPersonalInfo = new UserPersonalInfo()
  changePersonalInfo:ChangePersonalInfo=new ChangePersonalInfo();

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.changePersonalInfo.previousPassword='';
    this.changePersonalInfo.newPassword='',
    this.userService.getCurrentUserInfo().subscribe(data=>{
      this.personalInfo=data
      this.changePersonalInfo.email=this.personalInfo.email
      this.changePersonalInfo.firstName=this.personalInfo.firstName
      this.changePersonalInfo.lastName=this.personalInfo.lastName
      this.changePersonalInfo.phone=this.personalInfo.phone
      this.changePersonalInfo.street=this.personalInfo.address.split(",")[0]
      this.changePersonalInfo.city=this.personalInfo.address.split(",")[1]
      this.changePersonalInfo.country=this.personalInfo.address.split(",")[2]
    });
  }

  validatePassword() {
    this.validPassword = this.changePersonalInfo.previousPassword == this.changePersonalInfo.newPassword;
  }

  validateForm() {
    this.validForm =
      this.changePersonalInfo.firstName != '' &&
      this.changePersonalInfo.lastName != '' &&
      this.changePersonalInfo.phone != '' &&
      this.changePersonalInfo.street != '' &&
      this.changePersonalInfo.city != '' &&
      this.changePersonalInfo.country != '' &&
      this.changePersonalInfo.previousPassword != '' &&
      this.changePersonalInfo.newPassword != '' &&
      this.validPassword;

    if (this.validForm == true) {
      this.updateClient();
    }
  }

  updateClient() {
    this.userService.updateUserData(this.changePersonalInfo).subscribe((data) => {
      console.log(data);
      window.location.href = '/guest-db';
      this.changePersonalInfo.newPassword = '';
      alert('Changes saved!');
    });
  }
}
