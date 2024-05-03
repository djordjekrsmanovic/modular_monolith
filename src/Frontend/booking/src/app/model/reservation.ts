import { DateTimeSlot } from "./user-subscription";

export class Reservation{
    constructor(
        public id:string='',
        public start:Date,
        public end:Date
    ){}
}

export class ReservationView{
    constructor(
        public accommodationId:string='',
        public accommodation:string='',
        public address:string='',
        public price:string='',
        public reservationId:string='',
        public slot:DateTimeSlot=new DateTimeSlot()
    ){}
}

export class ReservationPaymentStatusesRequest{
    constructor(
        public reservationIds:string[]=[]
    ){}
}