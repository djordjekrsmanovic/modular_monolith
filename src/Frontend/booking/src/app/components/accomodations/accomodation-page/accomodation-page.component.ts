import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Accomodation } from 'src/app/model/accomodation';
import { AccommodationService } from 'src/app/service/accomodation.service';

@Component({
  selector: 'app-accomodation-page',
  templateUrl: './accomodation-page.component.html',
  styleUrls: ['./accomodation-page.component.css'],
})
export class AccomodationPageComponent implements OnInit {
  id: number = 0;
  cottage: Accomodation = new Accomodation();

  constructor(
    private route: ActivatedRoute,
    private cottageService: AccommodationService
  ) {}

  ngOnInit(): void {
    this.id = +this.route.snapshot.paramMap.get('id')!;

    this.cottageService.findById(this.id).subscribe((data) => {
      this.cottage = data;
    });
  }
}
