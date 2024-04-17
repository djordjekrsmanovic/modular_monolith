import { Component, Input, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserSubscription } from '../../../model/user-subscription';

@Component({
  selector: 'app-subscription',
  templateUrl: './subscription.component.html',
  styleUrls: ['./subscription.component.css']
})
export class SubscriptionComponent implements OnInit {

  @Input() subscription: UserSubscription=new UserSubscription();
  constructor() { }
  cardClass="subscription-card-silver"
  ngOnInit(): void {
  }

}
