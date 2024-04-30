import { Component, Input, OnInit } from '@angular/core';
import { ReservationRequest, ReservationRequestView } from '../../model/reservation-request';
import { UserService } from '../../service/user.service';
import { AccommodationService } from '../../service/accomodation.service';

@Component({
  selector: 'app-reservation-request',
  templateUrl: './reservation-request.component.html',
  styleUrls: ['./reservation-request.component.css']
})
export class ReservationRequestComponent implements OnInit {
  @Input() requestView:ReservationRequestView=new ReservationRequestView();
  constructor(private userService:UserService,private accommodationService:AccommodationService) { }
  isHost:boolean=false;
  ngOnInit(): void {
    this.isHost=this.userService.getCurrentUser().role=='Host'
  }

  cancel(){
    if (this.requestView.request.status!='Waiting'){
      alert('Request is not in waiting status');
      return;
    }

    this.accommodationService.cancelReservationRequest(this.requestView.request.id).subscribe(data=>{
      alert('Successfully Canceled')
      this.requestView.request.status='Canceled'
    },err=>{
      alert(err.error.detail);
    })
  }

  accept(){
    if (this.requestView.request.status!='Waiting'){
      alert('Request is not in waiting status');
      return;
    }
    this.accommodationService.acceptReservationRequest(this.requestView.request.id).subscribe(data=>{
      alert('Successfully Accepted')
      this.requestView.request.status='Accepted'
    },err=>{
      alert(err.error.detail);
    })
  }

}
