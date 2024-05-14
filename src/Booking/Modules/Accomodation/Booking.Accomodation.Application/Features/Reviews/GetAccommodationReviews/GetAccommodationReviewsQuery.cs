using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reviews.GetAccommodationReviews
{
    public sealed record GetAccommodationReviewsQuery(Guid accommodationId) : IQuery<List<ReviewResponse>>
    {
    }
}
