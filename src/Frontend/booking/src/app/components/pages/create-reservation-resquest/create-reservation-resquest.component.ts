import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AccommodationService } from '../../../service/accomodation.service';
import { UserService } from '../../../service/user.service';
import { CreateReservationRequest } from '../../../model/create-reservation-request';
import { CalculatePrice } from '../../../model/calculate-price';

@Component({
  selector: 'app-create-reservation-resquest',
  templateUrl: './create-reservation-resquest.component.html',
  styleUrls: ['./create-reservation-resquest.component.css']
})
export class CreateReservationResquestComponent implements OnInit {

  start:Date=new Date();
  end:Date=new Date();
  guestNumber:number=0;
  message:string='';
  price:string='0 EUR';
  calculatePrice:CalculatePrice=new CalculatePrice();
  reservationRequest:CreateReservationRequest=new CreateReservationRequest();
  constructor(private route: ActivatedRoute,private accommodationService:AccommodationService,private userService:UserService) { }

  ngOnInit(): void {
    this.reservationRequest.accommodationId=this.route.snapshot.paramMap.get('id')!;
  }

  confirm(){
    this.reservationRequest.guestId=this.userService.getCurrentUser().id;
    this.accommodationService.createReservationRequest(this.reservationRequest).subscribe(data=>{alert('Request created successfully')},err=>{
      alert(err.error.detail);
    })
  }
  recalculatePrice(){
    this.calculatePrice.accommodationId=this.reservationRequest.accommodationId;
    this.calculatePrice.end=this.reservationRequest.end;
    this.calculatePrice.start=this.reservationRequest.start;
    this.calculatePrice.guestNumber=this.reservationRequest.guestNumber;
    this.accommodationService.calculatePrice(this.calculatePrice).subscribe(data=>{
      this.price=data.value;
    })
  }

}
