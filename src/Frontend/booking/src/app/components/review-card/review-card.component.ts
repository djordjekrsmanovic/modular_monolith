import { Component, Input, OnInit } from '@angular/core';
import { Review } from 'src/app/model/review';

@Component({
  selector: 'review-card',
  templateUrl: './review-card.component.html',
  styleUrls: ['./review-card.component.css'],
})
export class ReviewCardComponent implements OnInit {
  @Input()
  review!: Review;
  constructor() {}

  ngOnInit(): void {}
  numSequence(n: number): Array<number> {
    return Array(n);
  }
}
