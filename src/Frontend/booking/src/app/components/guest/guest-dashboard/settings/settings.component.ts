import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';
import { ClientService } from 'src/app/service/guest.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css'],
})
export class SettingsComponent implements OnInit {
  @Input() user: Guest = new Guest();
  validPassword: boolean = true;
  validForm: boolean = true;

  constructor(private clientService: ClientService) {}

  ngOnInit(): void {
    this.user.password = '';
    this.user.passwordConfirm = '';
  }

  validatePassword() {
    this.validPassword = this.user.password == this.user.passwordConfirm;
  }

  validateForm() {
    this.validForm =
      this.user.name != '' &&
      this.user.lastName != '' &&
      this.user.phone != '' &&
      this.user.street != '' &&
      this.user.city != '' &&
      this.user.country != '' &&
      this.user.password != '' &&
      this.user.passwordConfirm != '' &&
      this.validPassword;

    if (this.validForm == true) {
      this.updateClient();
    }
  }

  updateClient() {
    this.clientService.updateClientData(this.user).subscribe((data) => {
      console.log(data);
      window.location.href = '/client-db';
      this.user.passwordConfirm = '';
      alert('Changes saved!');
    });
  }
}
