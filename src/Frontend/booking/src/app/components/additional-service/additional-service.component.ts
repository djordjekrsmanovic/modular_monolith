import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-additional-service',
  templateUrl: './additional-service.component.html',
  styleUrls: ['./additional-service.component.css']
})
export class AdditionalServiceComponent implements OnInit {
  @Input() additionalService: string = 'rule';
  constructor() { }

  ngOnInit(): void {
  }

}
