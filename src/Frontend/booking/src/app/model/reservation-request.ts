import { DateTimeSlot } from "./accommodation-view";

export class ReservationRequest {
    constructor(
      public id:string='',
      public accommodationId: string = '',
      public guestId:string='',
      public slot:DateTimeSlot=new DateTimeSlot(new Date(),new Date()),
      public guestNumber:number=0,
      public message:string='',
      public price:Money=new Money(),
      public status:string='',
    ) {}
  }

  export class Money {
    constructor(
      public ammount: number = 0,
      public currency:string='',
    ) {}
  }

export class ReservationRequestView{
    constructor(
        public request:ReservationRequest=new ReservationRequest(),
        public accommodation:string='',
      ) {}
}

