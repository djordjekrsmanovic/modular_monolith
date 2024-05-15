using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reviews.GetAccommodationReviews
{
    public sealed record GetAccommodationReviewsQuery(Guid accommodationId) : IQuery<List<ReviewResponse>>
    {
    }
}
