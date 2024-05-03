using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Domain.Errors
{
    public class ReservationErrors
    {
        public static Error ReservationNotExist = new("Reservation.NotExist", "Reservation does not exist");

        public static Error UnableToCancelInProgressReservation = new("Reservtion.UnableToCancelInProgressReservation", "Unable to cancel in progress reservation");
    }
}
