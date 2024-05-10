using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;

namespace Booking.Accomodation.Domain.Errors
{
    public class ReservationRequestErrors
    {
        public static readonly Error UnableToCreateReservationRequest = new("ReservationRequest.UnableToCreate", "Unable to create reservation request", ErrorType.BadRequest);
        public static readonly Error ReservationRequestAlreadyCanceled = new("ReservationRequest.AlreadyCanceled", "Reservation request is already canceled", ErrorType.BadRequest);
        public static readonly Error ReservationRequestIsAlreadyAccepted = new("ReservationRequest.AlreadyAccepted", "Reservation request is already accepted", ErrorType.BadRequest);
        public static readonly Error ReservationRequestNotExist = new("ReservationRequest.NotExist", "Reservation request does not exist", ErrorType.BadRequest);
    }
}
