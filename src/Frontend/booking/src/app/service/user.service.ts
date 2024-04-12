import {
  HttpClient,
  HttpErrorResponse,
  HttpHeaders,
  HttpResponse,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { server } from '../app-global';
import { ActiveUser, AuthRequest } from '../model/user-model';
import { Router } from '@angular/router';
import { ChangePersonalInfo, UserPersonalInfo } from '../model/personal-info-model';

@Injectable({
  providedIn: 'root',
})
export class UserService {

  url = `${server}api/users`;
  private user = new ActiveUser();

  constructor(private _http: HttpClient, private route: Router) {}

  login(request: AuthRequest) {
    return this._http.post<any>(`${this.url}/login`, request);
  }

  loginSetUser(activeUser: ActiveUser) {
    this.user = activeUser;
    console.log(this.user);
    localStorage.setItem('currentUser', JSON.stringify(this.user));
    window.location.href = '/';
  }

  logout() {
    this.user = new ActiveUser();
    localStorage.setItem('currentUser', JSON.stringify(this.user));
    window.location.href = '/';
  }

  getCurrentUser(): ActiveUser {
    return JSON.parse(localStorage.getItem('currentUser')!);
  }

  getHeaders() {
    const jwt = this.getCurrentUser().jwt;
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      Authorization: `Bearer ` + jwt,
    });
    return headers;
  }

  getUserInfo(id:string){
    const url = `${this.url}/${id}`;
    const headers = this.getHeaders();
    return this._http.get<UserPersonalInfo>(url, { headers: headers });
  }

  getCurrentUserInfo() {
    const id = this.getCurrentUser().id;
    const url = `${this.url}/${id}`;
    const headers = this.getHeaders();
    return this._http.get<UserPersonalInfo>(url, { headers: headers });
  }

  updateUserData(changePersonalInfo: ChangePersonalInfo) {
    console.log(changePersonalInfo);
    changePersonalInfo.id=this.getCurrentUser().id;
    const headers = this.getHeaders();
    return this._http.put<string>(this.url,changePersonalInfo, { headers: headers });
  }
}
