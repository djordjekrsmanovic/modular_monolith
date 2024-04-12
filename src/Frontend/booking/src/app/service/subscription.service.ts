import { Injectable } from "@angular/core";
import { server } from "../app-global";
import { HttpClient } from "@angular/common/http";
import { UserService } from "./user.service";

@Injectable({
    providedIn: 'root',
  })
  export class SubscriptionService {
    url = `${server}api/subscriptions`;

    constructor(private _http: HttpClient, private loginService: UserService) {}

    getSubscriptionPlans() {
      const headers = this.loginService.getHeaders();
      const url=`${this.url}/subscription-plans`
      return this._http.get<any>(url, { headers: headers });
    }


  }