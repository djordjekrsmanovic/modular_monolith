using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reviews.AddReview
{
    public sealed record AddReviewCommand(Guid ReservationId, Guid GuestId, string Comment, int Rating) : ICommand
    {
    }
}
