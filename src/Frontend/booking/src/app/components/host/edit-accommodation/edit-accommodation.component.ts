import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddAccommodation } from 'src/app/model/add-accommodation';
import { AdditionalService } from 'src/app/model/additiona-service';
import {Image} from 'src/app/model/image'
import * as CryptoJS from 'crypto-js';
import { AccommodationService } from 'src/app/service/accomodation.service';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import {  } from 'src/app/model/accommodation-view';
import { MyCalendarEvent } from '../../../model/interfaces/calendar-event';
import { CalendarEvent, CalendarView } from 'angular-calendar';
import { Subject } from 'rxjs';
import { ChangeTimeSlot } from '../../../model/calendar/change-time-slot';
import { AddAvilableTimePeriod } from '../../../model/calendar/add-available-time-period';
import { AccomodationView } from '../../../model/accommodation-view';
import { AvailableTimePeriod } from '../../../model/available-time-period';
import { DeleteAvailabilityPeriod } from '../../../model/delete-availability-period';
import { DomSanitizer } from '@angular/platform-browser';

@Component({
  selector: 'app-edit-accommodation',
  templateUrl: './edit-accommodation.component.html',
  styleUrls: ['./edit-accommodation.component.css']
})
export class EditAccommodationComponent implements OnInit {

  addAccommodation:AddAccommodation=new AddAccommodation();
  additionalServices:AdditionalService[]=[];
  selectedAdditionalService:AdditionalService[]=[];
  myForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });



  price:number=0;

  endDate:Date=new Date();

  startDate:Date=new Date();

  id:string='';
  street:string='';
  country:string='';
  city:string='';


  countries:any[]=[];
  private countriesUrl = 'https://restcountries.com/v3.1/all';

  accommodation: AccomodationView = new AccomodationView();
  accommodationsLoaded: boolean = false;
  constructor(private accommodationService:AccommodationService,private http: HttpClient,private route: ActivatedRoute,public sanitizer: DomSanitizer) { }

  ngOnInit(): void {
    this.getCountries()
    this.accommodationService.GetAdditionalServices().subscribe(data=>this.additionalServices=data);

    this.id =this.route.snapshot.paramMap.get('id')!;
    this.accommodationService.get(this.id).subscribe(data=>{
      this.accommodation=data;console.log(this.accommodation);
      this.street=this.accommodation.address.split(',')[0].trim();
      this.city=this.accommodation.address.split(',')[1].trim();
      this.country=this.accommodation.address.split(',')[2].trim();

      this.additionalServices.forEach(x => {
        var selected=false
        for(let i=0;i<this.accommodation.additionalServices.length;i++){

          if(this.accommodation.additionalServices[i]==x.name){
            selected=true;
            break;
          }
        }
        x.selected = selected;

    });
    this.accommodationsLoaded=true;
      console.log(this.additionalServices);
    });
  }

  getCountries() {
    this.http.get<any[]>(this.countriesUrl).subscribe(data=>{console.log(data);this.countries=data;console.log(this.countries[0].name.common)});
  }
  onFileChange(event: any) {
    if (event.target.files && event.target.files[0]) {
      var filesAmount = event.target.files.length;
      for (let i = 0; i < filesAmount; i++) {
        var reader = new FileReader();
        var name = event.target.files[0].name;
        reader.onload = (event: any) => {
          let image: Image = new Image();

          image.content = event.target.result;
          console.log('image content')
          console.log(image.content)
          image.extension = this.getExtension(event.target.result);
          image.name = name;
          let content=image.content.split(",")[1]
          image.hash=CryptoJS.SHA256(content).toString();
          this.accommodation.images.push(image);
          this.myForm.patchValue({
            fileSource: this.addAccommodation.images
          });
        }
        reader.readAsDataURL(event.target.files[i]);
      }
    }
  }



  getExtension(srcData: string) {
    var parts = srcData.split(",");
    let extension = parts[0].split(";")[0].split("/")[1];
    return extension;
  }

  deleteImage(image: Image) {
    const index = this.accommodation.images.indexOf(image);
    this.accommodation.images.splice(index, 1);
  }

  serviceSelected(service:AdditionalService){
    const index = this.selectedAdditionalService.findIndex(x => x.id === service.id);
    if (index === -1) {
      this.selectedAdditionalService.push(service);
    } else {
      this.selectedAdditionalService.splice(index, 1);
    }
  }

  submit(){
    console.log(this.accommodationService);
    this.addAccommodation.additionalServices=this.additionalServices;
    this.addAccommodation.name=this.accommodation.name;
    this.addAccommodation.city=this.city;
    this.addAccommodation.country=this.country;
    this.addAccommodation.description=this.accommodation.description;
    this.addAccommodation.hostId=this.accommodation.hostId;
    this.addAccommodation.maxGuest=this.accommodation.maxGuest;
    this.addAccommodation.minGuest=this.accommodation.minGuest;
    this.addAccommodation.pricePerGuest=Number.parseInt(this.accommodation.price.split(" ")[0].trim());
    this.addAccommodation.street=this.street;
    this.addAccommodation.images=this.accommodation.images;
    this.addAccommodation.id=this.id;
    console.log(this.addAccommodation);
    this.accommodationService.editAccommodation(this.addAccommodation).subscribe();
  }
  confirmAdding(){
    var availabilityPeriod=new AddAvilableTimePeriod(this.id,this.startDate,this.endDate,this.price)
    this.accommodationService.addAvailbleTime(availabilityPeriod).subscribe(data=>this.accommodation.availabilityPeriods.push(data),error=>{
      alert('Availability period overlaps with existing one');
    })
  }

  delete(period:AvailableTimePeriod){
    console.log(period);
    var deleteAvailabilityPeriod=new DeleteAvailabilityPeriod(period.accommodationId,period.id);
    this.accommodationService.deleteAvailabilityPeriod(deleteAvailabilityPeriod).subscribe((data:any)=>{this.accommodation.availabilityPeriods = this.accommodation.availabilityPeriods.filter(x => x.id !== period.id);}
    ,
    (error:any)=>{
      alert('Availability Period contains reservations!')
    })
  }

}


