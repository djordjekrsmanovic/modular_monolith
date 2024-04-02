import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddAccommodation } from 'src/app/model/add-accommodation';
import { AdditionalService } from 'src/app/model/additiona-service';
import {Image} from 'src/app/model/image'
import * as CryptoJS from 'crypto-js';
import { AccommodationService } from 'src/app/service/accomodation.service';

@Component({
  selector: 'app-add-accommodation',
  templateUrl: './add-accommodation.component.html',
  styleUrls: ['./add-accommodation.component.css']
})
export class AddAccommodationComponent implements OnInit {

  addAccommodation:AddAccommodation=new AddAccommodation();
  additionalServices:AdditionalService[]=[];
  selectedAdditionalService:AdditionalService[]=[];
  myForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(3)]),
    file: new FormControl('', [Validators.required]),
    fileSource: new FormControl('', [Validators.required])
  });
  constructor(private accommodationService:AccommodationService) { }

  ngOnInit(): void {
    const service1=new AdditionalService('1','Service 1');
    const service2=new AdditionalService('2','Service 2');
    const service3=new AdditionalService('3','Service 3');
    this.additionalServices[0]=service1;
    this.additionalServices[1]=service2;
    this.additionalServices[2]=service3;
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
          image.extension = this.getExtension(event.target.result);
          image.name = name;
          let content=image.content.split(",")[1]
          console.log(content);
          image.hash=CryptoJS.SHA256(content).toString();
          console.log(image.hash);
          this.addAccommodation.images.push(image);
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
    const index = this.addAccommodation.images.indexOf(image);
    this.addAccommodation.images.splice(index, 1);
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
    this.addAccommodation.additionalServices=this.selectedAdditionalService;
    console.log(this.addAccommodation);
    this.accommodationService.addAccommodation(this.addAccommodation).subscribe();
  }

}
