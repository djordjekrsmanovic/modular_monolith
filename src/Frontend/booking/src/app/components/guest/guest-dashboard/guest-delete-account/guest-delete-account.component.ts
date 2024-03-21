import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';

@Component({
  selector: 'guest-delete-account',
  templateUrl: './guest-delete-account.component.html',
  styleUrls: ['./guest-delete-account.component.css'],
})
export class GuestDeleteAccountComponent implements OnInit {
  @Input() user: Guest = new Guest();

  constructor() {}

  ngOnInit(): void {}
}
