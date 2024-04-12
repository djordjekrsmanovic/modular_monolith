export class Review{
    constructor(
        public guestId:string='',
        public createdAt:Date,
        public rating:number,
        public accommodationId:string,
        public comment:string
    ){}
}