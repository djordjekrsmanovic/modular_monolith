import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { server } from '../app-global';
import { AddAccommodation } from '../model/add-accommodation';
import { UserService } from './user.service';
import { SearchFilter } from '../model/search-filter';

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

  searchAccommodations(searchFilter:SearchFilter){

    const queryParams = [];

    if (searchFilter.text !== '') {
        queryParams.push(`SearchTerm=${encodeURIComponent(searchFilter.text)}`);
    }

    const sortTerm=searchFilter.sort.split('_')[0];
    const sortOrder=searchFilter.sort.split('_')[1];
    if (searchFilter.sort !== 'NO_SORT') {
        queryParams.push(`SortColumn=${encodeURIComponent(sortTerm)}`);
        queryParams.push(`SortOrder=${sortOrder}`); // Assuming ascending order by default
    }
    if (searchFilter.startDate) {
        queryParams.push(`StartDate=${(searchFilter.startDate)}`);
    }
    if (searchFilter.endDate) {
        queryParams.push(`EndDate=${searchFilter.endDate}`);
    }
    if (searchFilter.country !== '') {
        queryParams.push(`Country=${encodeURIComponent(searchFilter.country)}`);
    }
    if (searchFilter.tags.length > 0) {
        searchFilter.tags.forEach(tag => queryParams.push(`AdditionalServices=${encodeURIComponent(tag)}`));
    }
    if (searchFilter.people>0) {
      queryParams.push(`GuestNumber=${searchFilter.people}`);
    }
    // Assuming Page and PageSize are fixed
    queryParams.push('Page=1');
    queryParams.push('PageSize=10');

    console.log(queryParams)

    const uri=this.url + '?' + queryParams.join('&');

    return this._http.get<any>(uri);
  }

  formatDate(date: Date): string {
    const year = date.getFullYear();
    const month = ('0' + (date.getMonth() + 1)).slice(-2);
    const day = ('0' + date.getDate()).slice(-2);
    return `${year}-${month}-${day}`;
  }

  GetAdditionalServices() {
    const headers = this.loginService.getHeaders();
    const url=`${this.url}/additional-services`;
    return this._http.get<any>(url,{ headers: headers });
  }
}
