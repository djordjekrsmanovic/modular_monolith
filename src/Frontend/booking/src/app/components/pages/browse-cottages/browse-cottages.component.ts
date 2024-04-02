import { Component, OnInit } from '@angular/core';
import { Accomodation } from 'src/app/model/accomodation';
import { AccommodationService } from 'src/app/service/accomodation.service';

@Component({
  selector: 'app-browse-cottages',
  templateUrl: './browse-cottages.component.html',
  styleUrls: ['./browse-cottages.component.css'],
})
export class BrowseCottagesComponent implements OnInit {
  cottages: Accomodation[] = [];

  constructor(private cottageService: AccommodationService) {}

  ngOnInit(): void {
    this.cottageService.findAll().subscribe((data) => {
      this.cottages = data;
    });
  }
}
