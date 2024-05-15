using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reviews.AddReview
{
    public sealed record AddReviewCommand(Guid ReservationId, Guid GuestId, string Comment, int Rating) : ICommand
    {
    }
}
