using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Errors
{
    public class ReservationErrors
    {
        public static Error ReservationAlreadyPaidOrInProgress = new("Reservation.AlreadyPaidOrInProgress", "Reservation is paid or payment is processing");

        public static Error ReservationPaymentNotExist = new("Reservation.PaymentNotExist", "Reservation payment not exist");

        public static Error ReservationPaymentInWrongState = new("Reservation.PaymentInWrongState", "Reservation is not in in progress state");
    }
}
