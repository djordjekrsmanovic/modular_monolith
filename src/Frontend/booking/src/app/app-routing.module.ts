import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/pages/login/login.component';
import { NotFoundComponent } from './components/pages/not-found/not-found.component';
import { HomeComponent } from './components/pages/home/home.component';
import { RegisterComponent } from './components/pages/register/register.component';
import { ThankYouRegistrationComponent } from './components/pages/register/thank-you-registration/thank-you-registration.component';
import { GuestDashboardComponent } from './components/guest/guest-dashboard/guest-dashboard.component';
import { AccomodationOwnerDashboardComponent } from './components/accomodations/accomodation-owner-dashboard/accomodation-owner-dashboard.component';
import { BrowseAccommodationsComponent } from './components/pages/browse-accommodations/browse-accommodations.component';
import { ReviewsPageComponent } from './components/pages/reviews-page/reviews-page.component';
import { HostDashboardComponent } from './components/host/host-dashboard/host-dashboard.component';
import { AddAccommodationComponent } from './components/host/add-accommodation/add-accommodation.component';
import { AccommodationPageComponent } from './components/accomodations/accommodation-page/accommodation-page.component';
import { SubscriptionPlanComponent } from './components/subscription-plan/subscription-plan.component';
import { HostSubscriptionsPageComponent } from './components/host/host-subscriptions-page/host-subscriptions-page.component';
import { EditAccommodationComponent } from './components/host/edit-accommodation/edit-accommodation.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'host-db', component: HostDashboardComponent },
  { path: 'thank-you-registration', component: ThankYouRegistrationComponent },
  { path: 'accomodations', component: BrowseAccommodationsComponent },
  { path: 'reviews', component: ReviewsPageComponent },
  { path: 'guest-db', component: GuestDashboardComponent },
  { path: 'accomodation-owner-db', component: AccomodationOwnerDashboardComponent },
  { path: 'accomodation/:id', component: AccommodationPageComponent },
  { path: 'add-accommodation',component: AddAccommodationComponent},
  { path: 'edit-accomodation/:id', component: EditAccommodationComponent },
  { path: 'subscriptions',component: HostSubscriptionsPageComponent},
  { path: '', component: HomeComponent },
  { path: '**', component: NotFoundComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
