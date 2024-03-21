import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';

@Component({
  selector: 'client-past-accomodation',
  templateUrl: './past-accomodation.component.html',
  styleUrls: ['./past-accomodation.component.css']
})
export class PastAccomodationComponent implements OnInit {
  @Input() user: Guest = new Guest();

  constructor() { }

  ngOnInit(): void {
  }

}
