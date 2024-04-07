import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Accomodation } from 'src/app/model/accomodation';
import { AvailableTimePeriod } from 'src/app/model/available-time-period';
import { Reservation } from 'src/app/model/reservation';
import { AccommodationService } from 'src/app/service/accomodation.service';
import { GuestService } from 'src/app/service/guest.service';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-accommodation-page',
  templateUrl: './accommodation-page.component.html',
  styleUrls: ['./accommodation-page.component.css']
})
export class AccommodationPageComponent implements OnInit {

  id: number = 0;
  cottage: Accomodation = new Accomodation();
  reservations: Reservation[] = [];
  reservationsLoaded: boolean = true;
  image: any = 'assets/images/placeholder.jpg';
  //reviews: ReviewModel[] = [];
  isSubscribed: boolean = false;
  //actions: ActionModel[] = [];
  isClient: boolean = false;

  constructor(
    private route: ActivatedRoute,
    private cottageService: AccommodationService,
    private clientService: GuestService,
    private loginService: UserService
  ) {}

  ngOnInit(): void {
    this.id = +this.route.snapshot.paramMap.get('id')!;
    this.cottage.availableTimePeriods.push(new AvailableTimePeriod(new Date('01-01-2024'),new Date('01-01-2025'),12))




    // this.actionService.findAll().subscribe((data) => {
    //   for (let action of data) {
    //     if (
    //       action.entityId == this.cottage.id &&
    //       action.entityType == 'COTTAGE'
    //     ) {
    //       this.actions.push(action);
    //     }
    //   }
    // });
  }



  bookNowButton() {

  }

}
