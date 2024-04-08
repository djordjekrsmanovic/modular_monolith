import { AvailableTimePeriod } from "./available-time-period";
import { Reservation } from "./reservation";

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
      public ownerName: string = '',
      public images:string[]=[],
      public availabilityPeriods:AvailableTimePeriod[]=[],
      public reservations:Reservation[]=[]
    ) {}
  }

export class DateTimeSlot{
    constructor(
        public start:Date,
        public end:Date
    ){}
}