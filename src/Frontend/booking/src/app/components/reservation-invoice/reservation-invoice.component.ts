import { Component, Input, OnInit } from '@angular/core';
import { GuestReservationInvoice } from '../../model/reservation-invoice';

@Component({
  selector: 'app-reservation-invoice',
  templateUrl: './reservation-invoice.component.html',
  styleUrls: ['./reservation-invoice.component.css']
})
export class ReservationInvoiceComponent implements OnInit {

  @Input() invoice:GuestReservationInvoice=new GuestReservationInvoice();
  constructor() { }

  ngOnInit(): void {
  }

}
