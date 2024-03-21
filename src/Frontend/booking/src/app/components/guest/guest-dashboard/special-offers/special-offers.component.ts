import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';

@Component({
  selector: 'client-special-offers',
  templateUrl: './special-offers.component.html',
  styleUrls: ['./special-offers.component.css'],
})
export class SpecialOffersComponent implements OnInit {
  @Input() user: Guest = new Guest();

  constructor() {}

  ngOnInit(): void {}
}
