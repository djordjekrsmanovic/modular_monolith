import { Component, Input, OnInit } from '@angular/core';
import { SubscriptionInvoice } from '../../model/subscription-invoice';

@Component({
  selector: 'app-subscription-invoice',
  templateUrl: './subscription-invoice.component.html',
  styleUrls: ['./subscription-invoice.component.css']
})
export class SubscriptionInvoiceComponent implements OnInit {

  @Input() invoice:SubscriptionInvoice=new SubscriptionInvoice();
  constructor() { }

  ngOnInit(): void {
  }

}
