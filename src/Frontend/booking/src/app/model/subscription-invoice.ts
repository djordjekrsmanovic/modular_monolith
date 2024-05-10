export class SubscriptionInvoice{
    constructor(
        public invoiceId:string='',
        public subscriptionId:string='',
        public method:string='',
        public price:string='',
        public createdAt:Date=new Date()
    ){}
}