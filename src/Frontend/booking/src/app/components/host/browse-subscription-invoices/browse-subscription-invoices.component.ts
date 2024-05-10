import { Component, OnInit } from '@angular/core';
import { SubscriptionInvoice } from '../../../model/subscription-invoice';
import { InvoiceService } from '../../../service/invoice.service';

@Component({
  selector: 'app-browse-subscription-invoices',
  templateUrl: './browse-subscription-invoices.component.html',
  styleUrls: ['./browse-subscription-invoices.component.css']
})
export class BrowseSubscriptionInvoicesComponent implements OnInit {

  invoices:SubscriptionInvoice[]=[]
  dataLoaded:boolean=false;
  constructor(private invoiceService:InvoiceService) { }

  ngOnInit(): void {
    this.invoiceService.getSubscriptionInvoices().subscribe(data=>{
      this.invoices=data;
      this.dataLoaded=true;
    })
  }

}
