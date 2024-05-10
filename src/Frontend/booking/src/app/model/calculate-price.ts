export class CalculatePrice {
    constructor(
      public accommodationId: string = '',
      public start:Date=new Date(),
      public end:Date=new Date(),
      public guestNumber:number=0
    ) {}
  }