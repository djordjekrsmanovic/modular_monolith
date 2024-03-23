import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit, ɵgetInjectableDef } from '@angular/core';
import { Router } from '@angular/router';
import { RegistrationService } from '../../../service/registration.service';
import { UserRegistration } from 'src/app/model/register-user';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  user = new UserRegistration();
  validPassword: boolean = true;
  validEmail: boolean = true;
  validForm: boolean = true;

  passwordConfirm='';

  constructor(
    private registrationService: RegistrationService,
    private route: Router
  ) {}

  ngOnInit(): void {}

  validatePassword() {
    this.validPassword = this.user.password == this.passwordConfirm;
  }

  validateForm() {
    this.validForm =
      this.user.firstName != '' &&
      this.user.lastName != '' &&
      this.user.email != '' &&
      this.user.phone != '' &&
      this.user.street != '' &&
      this.user.city != '' &&
      this.user.country != '' &&
      this.user.password != '' &&
      this.passwordConfirm != '' &&
      this.validPassword;

    if (this.validForm) {
      this.registerUser();

    }
  }

  registerUser() {
    console.log(this.user);
    this.registrationService
      .register(this.user)
      .pipe(
        catchError(error => {
          alert(error.error.detail);
          return throwError(error);
        })
      )
      .subscribe(data => {
        alert("Succesffully registered, check your email to confirm registration!")
        this.route.navigate([''])
      });
  }
}
