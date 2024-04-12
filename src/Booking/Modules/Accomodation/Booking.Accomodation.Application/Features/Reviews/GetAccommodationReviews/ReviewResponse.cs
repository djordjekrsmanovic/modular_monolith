namespace Booking.Accomodation.Application.Features.Reviews.GetAccommodationReviews
{
    public record ReviewResponse(Guid GuestId, DateTime CreatedAt, Double Rating, Guid AccommodationId, string Comment)
    {
    }
}