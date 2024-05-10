import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UserService } from "./user.service";
import { server } from "../app-global";

@Injectable({
    providedIn: 'root',
  })
  export class InvoiceService {


    url = server + 'api/invoices';

    constructor(private _http: HttpClient,private loginService: UserService) {}

    getGuestInvoices(){
        const headers = this.loginService.getHeaders();
        const id=this.loginService.getCurrentUser().id;
        const url=`${this.url}/payer/${id}`
        return this._http.get<any>(url,{headers})
    }

    getSubscriptionInvoices() {
      const headers = this.loginService.getHeaders();
        const id=this.loginService.getCurrentUser().id;
        const url=`${this.url}/subscriber/${id}`
        return this._http.get<any>(url,{headers})
    }


  }
