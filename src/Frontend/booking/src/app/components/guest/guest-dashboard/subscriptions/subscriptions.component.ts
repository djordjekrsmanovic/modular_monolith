import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';

@Component({
  selector: 'app-subscriptions',
  templateUrl: './subscriptions.component.html',
  styleUrls: ['./subscriptions.component.css'],
})
export class SubscriptionsComponent implements OnInit {
  @Input() user: Guest = new Guest();
  hideNotification: boolean = false;

  constructor() {}

  ngOnInit(): void {}

  closeNotification() {
    this.hideNotification = true;
  }
}
