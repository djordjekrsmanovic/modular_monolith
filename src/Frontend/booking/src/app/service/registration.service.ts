import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { server } from 'src/app/app-global';
import { UserRegistration } from '../model/register-user';

@Injectable({
  providedIn: 'root',
})
export class RegistrationService {
  url = server + 'api/register';
  constructor(private _http: HttpClient) {}

  register(user: UserRegistration) {
    return this._http.post<any>(this.url, user);
  }

  confirmRegistration(verificationCode:string){
    const confirmationUrl=`${this.url}/confirm-registration?confirmation-code=${verificationCode}`
    console.log(confirmationUrl);
    return this._http.get<any>(confirmationUrl)
  }
  validateEmail(email: String) {
    let emailUrl = this.url + '/isEmailUnique/' + email;
    return this._http.get<boolean>(emailUrl);
  }
}
