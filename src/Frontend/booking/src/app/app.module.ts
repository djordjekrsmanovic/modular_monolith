import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/pages/home/home.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { AccomodationCardComponent } from './components/accomodations/accomodation-card/accomodation-card.component';
import { HeroTitleComponent } from './components/hero-title/hero-title.component';
import { TruncatePipe } from './pipes/truncate-pipe';
import { GapComponent } from './components/gap/gap.component';
import { NotFoundComponent } from './components/pages/not-found/not-found.component';
import { LoginComponent } from './components/pages/login/login.component';
import { RegisterComponent } from './components/pages/register/register.component';
import { ThankYouRegistrationComponent } from './components/pages/register/thank-you-registration/thank-you-registration.component';
import { FormsModule } from '@angular/forms';
import { UserHeaderComponent } from './components/header/user-header/user-header.component';
import { NewUserHeaderComponent } from './components/header/new-user-header/new-user-header.component';
import { GuestDashboardComponent } from './components/guest/guest-dashboard/guest-dashboard.component';
import { PersonalInfoComponent } from './components/guest/guest-dashboard/personal-info/personal-info.component';
import { SettingsComponent } from './components/guest/guest-dashboard/settings/settings.component';
import { SubscriptionsComponent } from './components/guest/guest-dashboard/subscriptions/subscriptions.component';
import { GuestReservationsComponent } from './components/guest/guest-dashboard/guest-reservations/guest-reservations.component';
import { SpecialOffersComponent } from './components/guest/guest-dashboard/special-offers/special-offers.component';
import { PastAccomodationComponent } from './components/guest/guest-dashboard/past-accomodation/past-accomodation.component';
import { GuestReviewsComponent } from './components/guest/guest-dashboard/guest-reviews/guest-reviews.component';
import { GuestComplaintsComponent } from './components/guest/guest-dashboard/guest-complaints/guest-complaints.component';
import { MyReviewsAndComplaintsComponent } from './components/guest/guest-dashboard/my-reviews-and-complaints/my-reviews-and-complaints.component';
import { GuestDeleteAccountComponent } from './components/guest/guest-dashboard/guest-delete-account/guest-delete-account.component';
import { ReservationCardComponent } from './components/guest/reservation-card/reservation-card.component';
import { SearchFieldComponent } from './components/search-field/search-field.component';
import { ReservationSearchComponent } from './components/guest/reservation-search/reservation-search.component';
import { BrowseAccommodationsComponent } from './components/pages/browse-accommodations/browse-accommodations.component';
import { ReviewsPageComponent } from './components/pages/reviews-page/reviews-page.component';
import { BrowseCardComponent } from './components/browse-card/browse-card.component';
import { ReviewCardComponent } from './components/review-card/review-card.component';
import { ComplaintCardComponent } from './components/complaint-card/complaint-card.component';
import { UtilityComponent } from './components/utility/utility.component';
import { MapComponent } from './components/map/map.component';
import { UpcomingReservationsComponent } from './components/guest/guest-dashboard/upcoming-reservations/upcoming-reservations.component';
import { HostDashboardComponent } from './components/host/host-dashboard/host-dashboard.component';
import { AddAccommodationComponent } from './components/host/add-accommodation/add-accommodation.component';
import { AccommodationPageComponent } from './components/accomodations/accommodation-page/accommodation-page.component';
import { CalendarComponent } from './components/calendar/calendar.component';
import { CalendarHeaderComponent } from './components/calendar/calendar-header/calendar-header.component';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { CommonModule } from '@angular/common';
import { FlatpickrModule } from 'angularx-flatpickr';
import { AdditionalServiceComponent } from './components/additional-service/additional-service.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { IvyCarouselModule } from 'angular-responsive-carousel';
import { SubscriptionPlanComponent } from './components/subscription-plan/subscription-plan.component';
import { HostSubscriptionsPageComponent } from './components/host/host-subscriptions-page/host-subscriptions-page.component';
import { SubscriptionComponent } from './components/host/subscription/subscription.component';
import { EditAccommodationComponent } from './components/host/edit-accommodation/edit-accommodation.component';

@NgModule({
  declarations: [
    TruncatePipe,
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    AccomodationCardComponent,
    HeroTitleComponent,
    GapComponent,
    NotFoundComponent,
    LoginComponent,
    RegisterComponent,
    ThankYouRegistrationComponent,
    UserHeaderComponent,
    NewUserHeaderComponent,
    GuestDashboardComponent,
    PersonalInfoComponent,
    SettingsComponent,
    SubscriptionsComponent,
    GuestReservationsComponent,
    SpecialOffersComponent,
    PastAccomodationComponent,
    GuestReviewsComponent,
    GuestComplaintsComponent,
    MyReviewsAndComplaintsComponent,
    GuestDeleteAccountComponent,
    ReservationCardComponent,
    SearchFieldComponent,
    ReservationSearchComponent,
    BrowseAccommodationsComponent,
    ReviewsPageComponent,
    BrowseCardComponent,
    ReviewCardComponent,
    ComplaintCardComponent,
    UtilityComponent,
    MapComponent,
    UpcomingReservationsComponent,
    HostDashboardComponent,
    AddAccommodationComponent,
    AccommodationPageComponent,
    CalendarComponent,
    CalendarHeaderComponent,
    AdditionalServiceComponent,
    CarouselComponent,
    SubscriptionPlanComponent,
    HostSubscriptionsPageComponent,
    SubscriptionComponent,
    EditAccommodationComponent
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule,NgbModalModule,
    FlatpickrModule.forRoot(),
    IvyCarouselModule,
    CalendarModule.forRoot({
      provide: DateAdapter,
      useFactory: adapterFactory,
    }),
    CommonModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
