export class SubscribeOnPlan {
    constructor(
      public subscriberId: string = '',
      public planId: string = '',
      public paymentMethod: string='',
    ) {}
  }