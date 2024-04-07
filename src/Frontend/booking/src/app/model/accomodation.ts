import { AvailableTimePeriod } from './available-time-period';
import { Utility } from './utility-model';

export class Accomodation {
  constructor(
    public id: number = 0,
    public rating: number = 0,
    public price: number = 0,
    public name: string = '',
    public address: string = '',
    public description: string = '',
    public guestLimit: number = 0,
    public rules: string[] = [],
    public utilities: Utility[] = [],
    public rooms: Room[] = [],
    public ownerName: string = '',
    public roomOverview: string = '',
    public availableTimePeriods: AvailableTimePeriod[] = []
  ) {}
}

export class Room {
  constructor(public id: number = 0, public numberOfBeds: number = 0) {}
}
