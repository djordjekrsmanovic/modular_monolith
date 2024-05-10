export class GuestReservationInvoice{
    constructor(
        public invoiceId:string='',
        public reservationId:string='',
        public method:string='',
        public price:string='',
        public createdAt:Date=new Date()
    ){}
}