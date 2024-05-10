using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reviews.AddReview
{
    public record AddReviewCommand(Guid ReservationId, Guid GuestId, string Comment, int Rating) : ICommand
    {
    }
}
