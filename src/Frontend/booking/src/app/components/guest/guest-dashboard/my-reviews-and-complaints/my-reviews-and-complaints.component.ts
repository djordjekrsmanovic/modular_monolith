import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';

@Component({
  selector: 'my-reviews-and-complaints',
  templateUrl: './my-reviews-and-complaints.component.html',
  styleUrls: ['./my-reviews-and-complaints.component.css'],
})
export class MyReviewsAndComplaintsComponent implements OnInit {
  @Input() user: Guest = new Guest();

  constructor() {}

  ngOnInit(): void {}
}
