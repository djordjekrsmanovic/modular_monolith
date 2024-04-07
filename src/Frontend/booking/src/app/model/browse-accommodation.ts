
export class BrowseAccommodation {
    constructor(
      public id: number = 0,
      public name: string = '',
      public address: string = '',
      public description: string = '',
      public guestLimit: number = 0,
      public additionalServices: string[] = [],
      public raiting: number=0,
      public price:number=0,
      public image:string=''
    ) {}
  }