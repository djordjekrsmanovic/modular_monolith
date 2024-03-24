import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { server } from '../app-global';
import { Guest } from '../model/guest';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class GuestService {
  url = server + 'api/client';

  constructor(private _http: HttpClient, private loginService: UserService) {}

  getClient(id: number) {
    const url = this.url + '/' + id;
    const headers = this.loginService.getHeaders();
    return this._http.get<Guest>(url, { headers: headers });
  }

  getCurrentUserInfo() {
    const id = this.loginService.getCurrentUser().id;
    const url = this.url + '/' + id;
    const headers = this.loginService.getHeaders();
    return this._http.get<Guest>(url, { headers: headers });
  }

  updateClientData(client: Guest) {
    const headers = this.loginService.getHeaders();
    return this._http.put<any>(this.url, client, { headers: headers });
  }
}
