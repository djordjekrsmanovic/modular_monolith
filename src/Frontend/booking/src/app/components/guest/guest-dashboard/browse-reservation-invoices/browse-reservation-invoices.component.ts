import { Component, OnInit } from '@angular/core';
import { GuestReservationInvoice } from '../../../../model/reservation-invoice';
import { InvoiceService } from '../../../../service/invoice.service';

@Component({
  selector: 'app-browse-reservation-invoices',
  templateUrl: './browse-reservation-invoices.component.html',
  styleUrls: ['./browse-reservation-invoices.component.css']
})
export class BrowseReservationInvoicesComponent implements OnInit {

  constructor(private invoiceService:InvoiceService) { }

  invoices:GuestReservationInvoice[]=[]
  dataLoaded:boolean=false;
  ngOnInit(): void {
    this.invoiceService.getGuestInvoices().subscribe(data=>{
      this.invoices=data;
      this.dataLoaded=true;
    })
  }

}
