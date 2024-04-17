import { Injectable } from "@angular/core";
import { server } from "../app-global";
import { HttpClient } from "@angular/common/http";
import { UserService } from "./user.service";
import { SubscriptionPlan } from "../model/subscription-plan";
import { SubscribeOnPlan } from "../model/subscribe-on-plan";

@Injectable({
    providedIn: 'root',
  })
  export class SubscriptionService {
    url = `${server}api/subscriptions`;

    constructor(private _http: HttpClient, private loginService: UserService,private userService:UserService) {}

    getSubscriptionPlans() {
      const headers = this.loginService.getHeaders();
      const url=`${this.url}/subscription-plans`
      return this._http.get<any>(url, { headers: headers });
    }

    subscribeOnPlan(request:SubscribeOnPlan){
      const headers = this.loginService.getHeaders();
      const url=`${this.url}/subscribe`
      return this._http.post<any>(url,request,{headers});
    }

    getUserSubscriptions(){
      const id=this.userService.getCurrentUser().id;
      const headers = this.loginService.getHeaders();
      const url=`${this.url}/user/${id}`
      return this._http.get<any>(url,{headers});
    }


  }