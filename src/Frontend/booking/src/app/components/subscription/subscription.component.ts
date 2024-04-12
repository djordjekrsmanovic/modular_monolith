import { Component, Input, OnInit } from '@angular/core';
import { SubscriptionPlan } from 'src/app/model/subscription-plan';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css']
})
export class SubscriptionComponent implements OnInit {
  @Input() plan: SubscriptionPlan=new SubscriptionPlan();
  constructor() { }

  ngOnInit(): void {
  }

}
