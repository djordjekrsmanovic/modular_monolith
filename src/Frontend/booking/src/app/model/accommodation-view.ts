import { AvailableTimePeriod } from "./available-time-period";
import { Reservation } from "./reservation";
import { Image } from "./image";
export class AccomodationView {
    constructor(
      public id: string = '',
      public raiting: number = 0,
      public price: string = '',
      public name: string = '',
      public address: string = '',
      public description: string = '',
      public guestLimit: number = 0,
      public additionalServices: string[] = [],
      public hostId: string = '',
      public images:Image[]=[],
      public availabilityPeriods:AvailableTimePeriod[]=[],
      public reservations:Reservation[]=[],
      public minGuest:number=0,
      public maxGuest:number=0,
      public requiredReservationRequest:boolean=false
    ) {}
  }

export class DateTimeSlot{
    constructor(
        public start:Date,
        public end:Date
    ){}
}