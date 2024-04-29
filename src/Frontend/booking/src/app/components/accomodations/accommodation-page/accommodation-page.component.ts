import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccomodationView } from 'src/app/model/accommodation-view';
import { Accomodation } from 'src/app/model/accomodation';
import { AvailableTimePeriod } from 'src/app/model/available-time-period';
import { UserPersonalInfo } from 'src/app/model/personal-info-model';
import { Reservation } from 'src/app/model/reservation';
import { Review } from 'src/app/model/review';
import { AccommodationService } from 'src/app/service/accomodation.service';
import { GuestService } from 'src/app/service/guest.service';
import { ReviewService } from 'src/app/service/review.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-accommodation-page',
  templateUrl: './accommodation-page.component.html',
  styleUrls: ['./accommodation-page.component.css']
})
export class AccommodationPageComponent implements OnInit {

  id: string='';
  accommodation: AccomodationView = new AccomodationView();
  accommodationsLoaded: boolean = false;
  image: any = 'assets/images/placeholder.jpg';
  ownerName:string='';
  //reviews: ReviewModel[] = [];
  isSubscribed: boolean = false;
  //actions: ActionModel[] = [];
  isClient: boolean = false;
  user:UserPersonalInfo=new UserPersonalInfo();
  reviews:Review[]=[];

  constructor(
    private route: ActivatedRoute,
    private accommodationService: AccommodationService,
    private userService: UserService,
    private reviewService: ReviewService
  ) {}

  ngOnInit(): void {
    this.id =this.route.snapshot.paramMap.get('id')!;
    this.accommodationService.get(this.id).subscribe(data=>{
      this.accommodation=data;console.log(this.accommodation);
      this.userService.getUserInfo(this.accommodation.hostId).subscribe((data:any)=>{this.ownerName=data.firstName+ " "+ data.lastName})
      this.reviewService.getReviewsForAccommodation(this.accommodation.id).subscribe(data=>this.reviews=data);
      this.accommodationsLoaded=true;});
  }



  bookNowButton() {
    window.location.href='add-reservation/'+this.id
  }

  openModalTab():void{

    document.getElementById('modal')?.classList.toggle('is-active');
  }

  closeModalTab():void{
    document.getElementById('modal')?.classList.toggle('is-active');
  }

  confirm(){

  }

}
