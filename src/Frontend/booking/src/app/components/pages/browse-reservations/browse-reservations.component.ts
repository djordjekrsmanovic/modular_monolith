import { Component, OnInit } from '@angular/core';
import { AccommodationService } from '../../../service/accomodation.service';
import { UserService } from '../../../service/user.service';
import { ReservationView } from '../../../model/reservation';

@Component({
  selector: 'app-browse-reservations',
  templateUrl: './browse-reservations.component.html',
  styleUrls: ['./browse-reservations.component.css']
})
export class BrowseReservationsComponent implements OnInit {

  reservations:ReservationView[]=[]
  isHost:boolean=false;
  isGuest:boolean=false;
  dataLoaded:boolean=false;

  constructor(private accommodationService:AccommodationService,private userService:UserService) { }

  ngOnInit(): void {
    this.isHost=this.userService.getCurrentUser().role=='Host'
    this.isGuest=this.userService.getCurrentUser().role=='Guest'
    if (this.isHost){
      this.accommodationService.getHostReservations(this.userService.getCurrentUser().id).subscribe(data=>{
        this.reservations=data.value;
        this.dataLoaded=true;
      })
    }
    if(this.isGuest){
      this.accommodationService.getGuestReservations(this.userService.getCurrentUser().id).subscribe(data=>{
        this.reservations=data.value;

        this.dataLoaded=true;
      })
    }
  }

}
