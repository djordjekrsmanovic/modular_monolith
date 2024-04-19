export class SubscriptionPlan {
    constructor(
      public id: string = '',
      public name: string = '',
      public description: string='',
      public price: string = '',
      public duration: number = 0,
      public accommodationLimit: number =0
    ) {}
  }