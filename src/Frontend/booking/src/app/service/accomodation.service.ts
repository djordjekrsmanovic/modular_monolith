import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { server } from '../app-global';
import { AddAccommodation } from '../model/add-accommodation';
import { UserService } from './user.service';

@Injectable({
  providedIn: 'root',
})
export class AccommodationService {
  url = server + 'api/accommodations';

  constructor(private _http: HttpClient,private loginService: UserService) {}

  findById(id: number) {
    return this._http.get<any>(this.url + '/' + id);
  }

  findAll() {
    return this._http.get<any>(this.url);
  }

  addAccommodation(accommodation:AddAccommodation){
    accommodation.hostId=this.loginService.getCurrentUser().id;
    const headers = this.loginService.getHeaders();
    return this._http.post<any>(this.url,accommodation,{ headers: headers });
  }
}
