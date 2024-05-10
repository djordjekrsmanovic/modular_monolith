using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;

namespace Booking.Accomodation.Domain.Errors
{
    public class AccommodationErrors
    {
        public static readonly Error ImageIsCorrupted = new("Accommodation.ImageCorrupted", "Image is corrupted", ErrorType.BadRequest);

        public static readonly Error IdNotExist = new("Accommodation.NotExistingId", "Accommodation with provided id does not exist", ErrorType.BadRequest);

        public static readonly Error AccommodationLimitExceeded = new("Accommodation.LimitExceeded", "Your subscription does not allow to create more accommodations", ErrorType.BadRequest);

        public static readonly Error ReservationWithSameDateAlreadyExist = new("Accommodation.ReservationWithSameDateAlreadyExist", "A reservation with the same data already exists.", ErrorType.BadRequest);

        public static readonly Error ReservationRequiresApproval = new Error("Accommodation.ReservationRequiresApproval", "Reservation requires approval of host, reservation request must be send.");
    }
}
