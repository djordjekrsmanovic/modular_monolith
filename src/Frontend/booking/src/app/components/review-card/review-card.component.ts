import { Component, Input, OnInit } from '@angular/core';
import { Review } from 'src/app/model/review';
import { UserPersonalInfo } from '../../model/personal-info-model';
import { UserService } from '../../service/user.service';

@Component({
  selector: 'review-card',
  templateUrl: './review-card.component.html',
  styleUrls: ['./review-card.component.css'],
})
export class ReviewCardComponent implements OnInit {
  @Input()
  review!: Review;
  constructor(private userService:UserService) {}

  userInfo:UserPersonalInfo=new UserPersonalInfo();

  ngOnInit(): void {
    this.userService.getUserInfo(this.review.guestId).subscribe(data=>{
      this.userInfo=data;
    })
  }
  numSequence(n: number): Array<number> {
    return Array(n);
  }
}
