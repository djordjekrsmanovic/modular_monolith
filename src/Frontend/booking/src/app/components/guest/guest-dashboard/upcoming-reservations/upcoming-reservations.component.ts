import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';

@Component({
  selector: 'client-upcoming-reservations',
  templateUrl: './upcoming-reservations.component.html',
  styleUrls: ['./upcoming-reservations.component.css'],
})
export class UpcomingReservationsComponent implements OnInit {
  @Input() user: Guest = new Guest();

  constructor() {}

  ngOnInit(): void {}
}
