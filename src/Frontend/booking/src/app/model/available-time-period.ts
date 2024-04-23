import { DateTimeSlot } from "./calendar/available-time-period";

export class AvailableTimePeriod {
    constructor(
      public id:string='',
      public accommodationId:string='',
      public slot:DateTimeSlot,
      public price:string=''
    ) {}
  }