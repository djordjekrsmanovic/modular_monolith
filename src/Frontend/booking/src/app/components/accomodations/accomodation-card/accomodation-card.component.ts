import { Component, OnInit, Input } from '@angular/core';
import { Accomodation } from 'src/app/model/accomodation';
import { AccommodationService } from 'src/app/service/accomodation.service';

@Component({
  selector: 'accomodation-card',
  templateUrl: './accomodation-card.component.html',
  styleUrls: ['./accomodation-card.component.css'],
})
export class AccomodationCardComponent implements OnInit {
  @Input() id: number = 0;
  @Input() cottage: Accomodation = new Accomodation();
  @Input() img: string = '/assets/images/cottage-interior/interior1.jpeg';

  constructor(private cottageService: AccommodationService) {}

  ngOnInit(): void {
    this.cottageService.findById(this.id).subscribe((data) => {
      this.cottage = data;
    });
  }

  readMore() {
    window.location.href = 'cottage/' + this.id;
  }
}
