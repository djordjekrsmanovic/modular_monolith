using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;

namespace Booking.AccommodationNS.Domain.Errors
{
    public class ReviewErrors
    {
        public static readonly Error ReservationReviewAlreadyExist = new("Review.ReservationReviewAlreadyExist", "Review for reservation is already submitted", ErrorType.BadRequest);
        public static readonly Error GuestDoesNotExist = new("Review.GuestDoesNotExist", "Guest does not exist", ErrorType.BadRequest);
    }
}
