import { Component, Input, OnInit } from '@angular/core';
import { SubscriptionPlan } from 'src/app/model/subscription-plan';
import { SubscribeOnPlan } from '../../model/subscribe-on-plan';
import { UserService } from '../../service/user.service';
import { SubscriptionService } from '../../service/subscription.service';

@Component({
  selector: 'app-subscription-plan',
  templateUrl: './subscription-plan.component.html',
  styleUrls: ['./subscription-plan.component.css']
})
export class SubscriptionPlanComponent implements OnInit {
  @Input() plan: SubscriptionPlan=new SubscriptionPlan();
  cardClass:string='';
  constructor(private userService:UserService,private subscriptionService:SubscriptionService) { }

  paymentMethod:string='';

  ngOnInit(): void {
    console.log(this.plan)
    if(this.plan.name=='Gold'){
      this.cardClass='subscription-card-gold'
    }else if(this.plan.name='Silver'){
      this.cardClass='subscription-card-silver'
    }else{
      this.cardClass='subscription-card'
    }
  }

  openModalTab():void{

    document.getElementById('modal')?.classList.toggle('is-active');
  }

  closeModalTab():void{
    document.getElementById('modal')?.classList.toggle('is-active');
  }

  confirm(){
    let subscribeOnPlan=new SubscribeOnPlan(this.userService.getCurrentUser().id,this.plan.id,this.paymentMethod);
    console.log(subscribeOnPlan);
    this.subscriptionService.subscribeOnPlan(subscribeOnPlan).subscribe(data=>{},error=>{alert('User is already subscribed on plan')});
  }

}
