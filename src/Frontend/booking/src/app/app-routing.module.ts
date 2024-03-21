import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/pages/login/login.component';
import { NotFoundComponent } from './components/pages/not-found/not-found.component';
import { HomeComponent } from './components/pages/home/home.component';
import { RegisterComponent } from './components/pages/register/register.component';
import { ThankYouRegistrationComponent } from './components/pages/register/thank-you-registration/thank-you-registration.component';
import { GuestDashboardComponent } from './components/guest/guest-dashboard/guest-dashboard.component';
import { AccomodationOwnerDashboardComponent } from './components/accomodations/accomodation-owner-dashboard/accomodation-owner-dashboard.component';
import { BrowseCottagesComponent } from './components/pages/browse-cottages/browse-cottages.component';
import { ReviewsPageComponent } from './components/pages/reviews-page/reviews-page.component';
import { AccomodationPageComponent } from './components/accomodations/accomodation-page/accomodation-page.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'thank-you-registration', component: ThankYouRegistrationComponent },
  { path: 'accomodations', component: BrowseCottagesComponent },
  { path: 'reviews', component: ReviewsPageComponent },
  { path: 'guest-db', component: GuestDashboardComponent },
  { path: 'accomodation-owner-db', component: AccomodationOwnerDashboardComponent },
  { path: 'accomodation/:id', component: AccomodationPageComponent },
  { path: '', component: HomeComponent },
  { path: '**', component: NotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
