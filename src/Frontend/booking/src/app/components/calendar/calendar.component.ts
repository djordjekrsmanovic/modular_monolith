import { Component, Input, OnInit } from '@angular/core';
import {
  CalendarEvent,
  CalendarDateFormatter,
  CalendarView,
} from 'angular-calendar';
import { CustomDateFormatter } from './calendar-date-formatter.provider';
import { colors } from './calendar-colors';
import { AvailableTimePeriod } from 'src/app/model/available-time-period';
import { Reservation } from 'src/app/model/reservation';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css'],
  providers: [
    {
      provide: CalendarDateFormatter,
      useClass: CustomDateFormatter,
    },
  ],
})
export class CalendarComponent implements OnInit {

  view: CalendarView = CalendarView.Month;
  viewDate: Date = new Date();
  events: CalendarEvent[] = [];
  @Input() availableDates: AvailableTimePeriod[] = [];
  @Input() reservationDates: Reservation[] = [];

  constructor() {}

  ngOnInit(): void {
    this.events = [];
    for (let date of this.availableDates) {
      let event = {
        title: 'Available',
        start: new Date(date.start),
        end: new Date(date.end),
        allDay: false,
        color: colors.green,
      };

      this.events.push(event);
    }

    for (let date of this.reservationDates) {
      let event = {
        title: 'Booked',
        start: new Date(date.start),
        end: new Date(date.end),
        allDay: false,
        color: colors.red,
      };

      this.events.push(event);
    }
  }

}
