export class ExecuteReservationPayment {
    constructor(
        public reservationId:string='',
        public method:string='',
        public payerId:string=''

    ) {}
  }