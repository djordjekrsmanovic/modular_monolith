import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { RegistrationService } from 'src/app/service/registration.service';

@Component({
  selector: 'app-thank-you-registration',
  templateUrl: './thank-you-registration.component.html',
  styleUrls: ['./thank-you-registration.component.css']
})
export class ThankYouRegistrationComponent implements OnInit {

  confirmationCode: string | null='';
  registrationVerified: Boolean=false;


  constructor(private route: ActivatedRoute,private registrationService: RegistrationService,) { }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.confirmationCode = params['confirmation-code'];
      // You can use this.confirmationCode here as needed
    });
    if (this.confirmationCode===null){
      alert('Verifaction code is unvalid');
    }else{
      this.registrationService.confirmRegistration(this.confirmationCode)
      .pipe(
        catchError(error => {
          alert(error.error.detail);
          return throwError(error)
        })
      )
      .subscribe(data => {
        this.registrationVerified=true
      });
    }

  }

}
