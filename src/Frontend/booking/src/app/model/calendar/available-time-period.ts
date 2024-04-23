export class AvailableTimePeriod{
    constructor(
        public id:string='',
        public accommodationId:string='',
        public slot:DateTimeSlot,
        public price:string='',
    ){

    }
}

export class DateTimeSlot{
    constructor(
        public start:Date,
        public end:Date
    ){

    }
}