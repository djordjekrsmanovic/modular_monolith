using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Domain.Errors
{
    public class AvailabilityPeriodErrors
    {
        public static readonly Error PeriodNotExist = new("AvailabilityPeriod.NotExist", "Availability period not exist");
        public static readonly Error AvailaibilityPerodOverlapsWithExisting = new("AvailabilityPeriod.OverlapsWithExisting", "Provided availability period overlaps with existing one");

        public static readonly Error EndDateAfterSubscriptionExpiration = new("AvailabilityPeriod.EndDateAfterSubscriptionExpiration", "End date for availability period can not be after subscription expiration date");

        public static readonly Error AvailabilityPeriodContainsReservations = new("AvailabilityPeriod.ReservationsAlreadyExists", "Reservation exists in availability period");
    }
}
