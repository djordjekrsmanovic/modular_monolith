namespace Booking.Accomodation.Application.Features.Reviews.GetAccommodationReviews
{
    public sealed record ReviewResponse(Guid GuestId, DateTime CreatedAt, Double Rating, Guid AccommodationId, string Comment)
    {
    }
}