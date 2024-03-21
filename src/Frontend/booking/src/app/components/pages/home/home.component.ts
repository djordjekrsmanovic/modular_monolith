import { Component, OnInit } from '@angular/core';
import { Accomodation } from 'src/app/model/accomodation';
import { AccomodationService } from 'src/app/service/accomodation.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {

  cottages: Accomodation[] = [];

  constructor(
    private cottageService: AccomodationService
  ) {}

  ngOnInit(): void {

    this.cottageService.findAll().subscribe((data) => {
      this.cottages = data;
    });
  }
}
