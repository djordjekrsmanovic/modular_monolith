export class Review{
    constructor(
        public guestId:string='',
        public createdAt:Date,
        public rating:number,
        public accommodationId:string,
        public comment:string
    ){}
}

export class AddReviewRequest{
    constructor(
        public reservationId:string='',
        public guestId:string='',
        public rating:number=1,
        public comment:string=''
    ){}
}