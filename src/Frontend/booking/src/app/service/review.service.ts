import { Injectable } from "@angular/core";
import { server } from "../app-global";
import { HttpClient } from "@angular/common/http";
import { UserService } from "./user.service";
import { AddReviewRequest } from "../model/review";

@Injectable({
    providedIn: 'root',
  })
  export class ReviewService {
    url = `${server}api/reviews`;

    constructor(private _http: HttpClient, private loginService: UserService) {}

    getReviewsForAccommodation(accommodationId: string) {
      const url = `${this.url}/accommodation/${accommodationId}`
      const headers = this.loginService.getHeaders();
      return this._http.get<any>(url, { headers: headers });
    }

    addReview(request:AddReviewRequest){
      const url=this.url;
      const headers=this.loginService.getHeaders();
      return this._http.post<any>(url,request,{headers:headers});
    }


  }