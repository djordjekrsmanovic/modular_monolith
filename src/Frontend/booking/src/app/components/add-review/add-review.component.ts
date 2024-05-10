import { Component, OnInit } from '@angular/core';
import { AddReviewRequest } from '../../model/review';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../service/user.service';
import { ReviewService } from '../../service/review.service';

@Component({
  selector: 'app-add-review',
  templateUrl: './add-review.component.html',
  styleUrls: ['./add-review.component.css']
})
export class AddReviewComponent implements OnInit {

  reservationId:string='';
  addReview:AddReviewRequest=new AddReviewRequest();
  constructor(private route: ActivatedRoute,private userService:UserService,private reviewService:ReviewService) { }

  ngOnInit(): void {
    this.reservationId =this.route.snapshot.paramMap.get('id')!;
  }

  confirm(){
    this.addReview.reservationId=this.reservationId;
    this.addReview.guestId=this.userService.getCurrentUser().id
    this.reviewService.addReview(this.addReview).subscribe(data=>{alert('Review successfully submited')},err=>{
      alert(err.error.detail)
    })
  }

}
