import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';

@Component({
  selector: 'client-guest-reservations',
  templateUrl: './guest-reservations.component.html',
  styleUrls: ['./guest-reservations.component.css'],
})
export class GuestReservationsComponent implements OnInit {
  @Input() user: Guest = new Guest();

  constructor() {}

  ngOnInit(): void {}
}
