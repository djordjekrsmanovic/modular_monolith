import { Component, Input, OnInit } from '@angular/core';
import { ReservationRequestView } from '../../../model/reservation-request';
import { AccommodationService } from '../../../service/accomodation.service';
import { UserService } from '../../../service/user.service';

@Component({
  selector: 'app-browse-reservation-requests',
  templateUrl: './browse-reservation-requests.component.html',
  styleUrls: ['./browse-reservation-requests.component.css']
})
export class BrowseReservationRequestsComponent implements OnInit {

  reservationRequests:ReservationRequestView[]=[];
  userId:string='';
  @Input() userType:string='';
  dataLoaded=false;
  constructor(private accommodationService:AccommodationService,private userService:UserService) { }

  ngOnInit(): void {
    this.userId=this.userService.getCurrentUser().id;
    if(this.userService.getCurrentUser().role=='Host'){
      this.accommodationService.getHostReservationRequest(this.userId).subscribe(data=>{
        console.log(data);
        this.reservationRequests=data.value;
        this.dataLoaded=true;
        console.log(this.reservationRequests);
      })
    }
  }

}
