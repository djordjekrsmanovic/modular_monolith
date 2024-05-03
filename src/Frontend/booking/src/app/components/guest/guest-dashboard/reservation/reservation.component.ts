import { Component, Input, OnInit } from '@angular/core';
import { ReservationView } from '../../../../model/reservation';
import { AccommodationService } from '../../../../service/accomodation.service';
import { ExecuteReservationPayment } from '../../../../model/execute-reservation-payment';
import { UserService } from '../../../../service/user.service';


@Component({
  selector: 'client-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css'],
})
export class ReservationComponent implements OnInit {

  @Input() reservation:ReservationView=new ReservationView();

  paymentMethod:string=''

  status:string='';

  dataLoaded=false;

  isGuest:boolean=false;

  constructor(private accommodationService:AccommodationService,private userService:UserService) {}

  ngOnInit(): void {
    this.accommodationService.getReservationPaymentStatus(this.reservation.reservationId).subscribe((data)=>{this.status=data.status; console.log(data);this.dataLoaded=true;})
    this.isGuest=this.userService.getCurrentUser().role=='Guest';
  }

  cancel(){

  }

  pay(){

  }

  confirm(){
    var executePayment:ExecuteReservationPayment=new ExecuteReservationPayment();
    executePayment.reservationId=this.reservation.reservationId;
    executePayment.method=this.paymentMethod;
    this.accommodationService.executeReservationPayment(executePayment).subscribe(data=>{alert('Payment Created');},err=>{
      alert(err.error.detail);
    })
  }

  openModalTab():void{

    document.getElementById('modal')?.classList.toggle('is-active');
  }

  closeModalTab():void{
    document.getElementById('modal')?.classList.toggle('is-active');
  }

  confirmGuestPayment(){
    alert('confirm')
    var executePayment:ExecuteReservationPayment=new ExecuteReservationPayment();
    executePayment.reservationId=this.reservation.reservationId;
    executePayment.method='Cash';
    this.accommodationService.confirmReservationPayment(executePayment).subscribe(data=>{alert('Payment Confirmed');},err=>{
      alert(err.error.detail);
    })
  }

}
