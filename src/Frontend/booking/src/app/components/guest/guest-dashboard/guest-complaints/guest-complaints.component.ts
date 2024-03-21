import { Component, Input, OnInit } from '@angular/core';
import { Guest } from 'src/app/model/guest';

@Component({
  selector: 'guest-complaints',
  templateUrl: './guest-complaints.component.html',
  styleUrls: ['./guest-complaints.component.css'],
})
export class GuestComplaintsComponent implements OnInit {
  @Input() user: Guest = new Guest();

  constructor() {}

  ngOnInit(): void {}
}
