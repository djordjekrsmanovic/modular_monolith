import { Component, Input, OnInit } from '@angular/core';
import { ReservationView } from '../../../../model/reservation';


@Component({
  selector: 'client-reservation',
  templateUrl: './reservation.component.html',
  styleUrls: ['./reservation.component.css'],
})
export class ReservationComponent implements OnInit {

  @Input() reservation:ReservationView=new ReservationView();

  constructor() {}

  ngOnInit(): void {}
}
