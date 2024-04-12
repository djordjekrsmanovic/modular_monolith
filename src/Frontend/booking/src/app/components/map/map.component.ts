import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import * as L from 'leaflet';


@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.css'],
})
export class MapComponent implements OnInit {
  @Input() address: string = 'Bahami';
  private map: L.Map;
  private centroid: L.LatLngExpression=[0,0]; //
  private nominatimBaseUrl = 'https://nominatim.openstreetmap.org/';
  public loaded=false;
  private initMap(): void {
    this.loaded=true
    console.log(this.centroid)
    this.map = L.map('map', {
      center: this.centroid,
      zoom: 5
    });

    const tiles = L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      maxZoom: 18,
      minZoom: 10,
      attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });
    tiles.addTo(this.map);
    L.marker(this.centroid).addTo(this.map);
  }

  constructor(private http: HttpClient) {
    this.map = {} as L.Map; // Initialize map property
   }

  ngOnInit(): void {
    const url = `${this.nominatimBaseUrl}search?q=${encodeURIComponent(this.address)}&format=json&limit=1`;
    this.http.get(url).subscribe((response:any)=>{const latitude = response[0].lat;
      const longitude = response[0].lon;
      this.centroid=[latitude,longitude ];
      this.initMap();
    });

  }
}
