import { Component, Input, OnInit } from '@angular/core';
import { Utility } from 'src/app/model/utility-model';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'browse-card',
  templateUrl: './browse-card.component.html',
  styleUrls: ['./browse-card.component.css'],
})
export class BrowseCardComponent implements OnInit {
  @Input() name: string = '';
  @Input() description: string = '';
  @Input() address: string = '';
  @Input() price: number = 0;
  @Input() rating: number = 0;
  @Input() utilities: string[] = [];
  @Input() image: any;
  @Input() showEdit:boolean=false;

  @Input() id: number = 0;
  @Input() type: string = 'entity';

  constructor(public sanitizer: DomSanitizer) {}

  ngOnInit(): void {}

  readMore() {
    window.location.href = this.type + '/' + this.id;
  }

  edit() {
    window.location.href = 'edit-accommodation' + '/' + this.id;
  }
}
