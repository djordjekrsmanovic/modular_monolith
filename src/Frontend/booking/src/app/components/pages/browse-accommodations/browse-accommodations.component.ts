import { HttpClient } from '@angular/common/http';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Observable } from 'rxjs';
import { Accomodation } from 'src/app/model/accomodation';
import { BrowseAccommodation } from 'src/app/model/browse-accommodation';
import { SearchFilter } from 'src/app/model/search-filter';
import { AccommodationService } from 'src/app/service/accomodation.service';

@Component({
  selector: 'app-browse-accommodations',
  templateUrl: './browse-accommodations.component.html',
  styleUrls: ['./browse-accommodations.component.css'],
})
export class BrowseAccommodationsComponent implements OnInit {
  @Output() doSearch: EventEmitter<SearchFilter> = new EventEmitter();
  countries:any[]=[];
  private countriesUrl = 'https://restcountries.com/v3.1/all';
  accommodations: BrowseAccommodation[] = [];
  searchFilter = new SearchFilter();

  constructor(private http: HttpClient,private accommodationService:AccommodationService) {}

  ngOnInit(): void {
    this.getCountries();
  }

  getCountries() {
    this.http.get<any[]>(this.countriesUrl).subscribe(data=>{console.log(data);this.countries=data;this.countries = this.countries.sort((x, y) => {
      if (x.name.common < y.name.common) return -1;
      if (x.name.common > y.name.common) return 1;
      return 0;
  });
      console.log(this.countries[0].name.common)});
  }

  search(filter: SearchFilter) {
    this.searchFilter.tags = filter.tags;
    this.searchFilter.sort = filter.sort;
    this.searchFilter.text = filter.text;
    console.log(this.searchFilter);
    this.accommodationService.searchAccommodations(this.searchFilter).subscribe(data=>this.accommodations=data);
  }
}
