export class AddAvilableTimePeriod{
    constructor(
        public accommodationId:string='',
        public start:Date=new Date(),
        public end:Date=new Date(),
        public pricePerGuest:number=0,
    ){

    }
}