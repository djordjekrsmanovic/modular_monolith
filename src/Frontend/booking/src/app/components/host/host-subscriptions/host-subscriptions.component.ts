import { Component, OnInit } from '@angular/core';
import { SubscriptionPlan } from 'src/app/model/subscription-plan';
import { SubscriptionService } from 'src/app/service/subscription.service';

@Component({
  selector: 'app-host-subscriptions',
  templateUrl: './host-subscriptions.component.html',
  styleUrls: ['./host-subscriptions.component.css']
})
export class HostSubscriptionsComponent implements OnInit {

  constructor(private subscriptionService:SubscriptionService) { }
  plans:SubscriptionPlan[]=[];
  ngOnInit(): void {
    this.subscriptionService.getSubscriptionPlans().subscribe(data=>{
      this.plans=data;
    })
  }

}
