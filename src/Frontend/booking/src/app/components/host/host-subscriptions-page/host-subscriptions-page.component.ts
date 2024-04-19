import { Component, OnInit } from '@angular/core';
import { SubscriptionPlan } from 'src/app/model/subscription-plan';
import { SubscriptionService } from 'src/app/service/subscription.service';
import { UserSubscription } from '../../../model/user-subscription';

@Component({
  selector: 'app-host-subscriptions-page',
  templateUrl: './host-subscriptions-page.component.html',
  styleUrls: ['./host-subscriptions-page.component.css']
})
export class HostSubscriptionsPageComponent implements OnInit {

  constructor(private subscriptionService:SubscriptionService) { }
  plans:SubscriptionPlan[]=[];
  subscriptions:UserSubscription[]=[];
  ngOnInit(): void {
    this.subscriptionService.getSubscriptionPlans().subscribe(data=>{
      this.plans=data;
    })
    this.subscriptionService.getUserSubscriptions().subscribe(data=>{
      this.subscriptions=data;
    })
  }

}
