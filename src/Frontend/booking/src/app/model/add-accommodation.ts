import { AdditionalService } from "./additiona-service";
import {Image} from "./image"

export class AddAccommodation {
    constructor(
      public id:string='',
      public name: string = '',
      public description: string = '',
      public street:string='',
      public city:string='',
      public country:string='',
      public minGuest: number = 0,
      public maxGuest: number = 0,
      public pricePerGuest: number = 0,
      public additionalServices: AdditionalService[] = [],
      public hostId: string = '',
      public images: Image[] = [], //url encoded images with name and extension
      public ReservationApprovalRequired:boolean=false
    ) {}
  }