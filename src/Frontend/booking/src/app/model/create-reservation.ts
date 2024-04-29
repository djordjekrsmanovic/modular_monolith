export class CreateReservation {
    constructor(
      public accommodationId: string = '',
      public guestId:string='',
      public start:Date=new Date(),
      public end:Date=new Date(),
      public guestNumber:number=0
    ) {}
  }