import { SubscriptionPlan } from "./subscription-plan";

export class UserSubscription {
    constructor(
      public plan:SubscriptionPlan=new SubscriptionPlan(),
      public subscriptionPeriod:DateTimeSlot=new DateTimeSlot(),
      public status:string=''
    ) {}
}

export class DateTimeSlot{
    constructor(
        public start:Date=new Date(),
        public end:Date=new Date(),
    ) {}
}