import { Component, OnInit } from '@angular/core';
import { BrowseAccommodation } from 'src/app/model/browse-accommodation';
import { AccommodationService } from 'src/app/service/accomodation.service';
@Component({
  selector: 'app-my-accommodations',
  templateUrl: './my-accommodations.component.html',
  styleUrls: ['./my-accommodations.component.css']
})
export class MyAccommodationsComponent implements OnInit {
  accommodations: BrowseAccommodation[] = [];
  constructor(private accommodationService:AccommodationService) { }

  ngOnInit(): void {
    this.accommodationService.getHostAccommodations().subscribe(data=>{
      this.accommodations=data;
    })
  }

}
