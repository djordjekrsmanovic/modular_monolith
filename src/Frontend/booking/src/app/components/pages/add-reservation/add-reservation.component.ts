import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CalculatePrice } from '../../../model/calculate-price';
import { AccommodationService } from '../../../service/accomodation.service';
import { CreateReservation } from '../../../model/create-reservation';
import { UserService } from '../../../service/user.service';


@Component({
  selector: 'app-add-reservation',
  templateUrl: './add-reservation.component.html',
  styleUrls: ['./add-reservation.component.css']
})
export class AddReservationComponent implements OnInit {

  calculatePrice:CalculatePrice=new CalculatePrice();
  createReservation:CreateReservation=new CreateReservation();
  constructor(private route: ActivatedRoute,private accommodationService:AccommodationService,private userService:UserService) { }
  price:string='0 EUR';

  ngOnInit(): void {
    this.calculatePrice.accommodationId=this.route.snapshot.paramMap.get('id')!;

  }

  recalculatePrice(){
    this.accommodationService.calculatePrice(this.calculatePrice).subscribe(data=>{
      this.price=data.value;
    })
  }

  confirm(){
    this.createReservation.accommodationId=this.calculatePrice.accommodationId;
    this.createReservation.guestId=this.userService.getCurrentUser().id;
    this.createReservation.guestNumber=this.calculatePrice.guestNumber;
    this.createReservation.start=this.calculatePrice.start;
    this.createReservation.end=this.calculatePrice.end;
    this.accommodationService.createReservation(this.createReservation).subscribe(data=>{alert('Reservation Created')},
    err=>{alert('Unable to create reservation')})
  }

}
