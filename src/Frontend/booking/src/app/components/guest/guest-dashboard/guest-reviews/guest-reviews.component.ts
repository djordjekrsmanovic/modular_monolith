import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';
import { UserPersonalInfo } from 'src/app/model/personal-info-model';

@Component({
  selector: 'guest-reviews',
  templateUrl: './guest-reviews.component.html',
  styleUrls: ['./guest-reviews.component.css'],
})
export class GuestReviewsComponent implements OnInit {
  @Input() user: UserPersonalInfo = new UserPersonalInfo();

  constructor() {}

  ngOnInit(): void {}
}
