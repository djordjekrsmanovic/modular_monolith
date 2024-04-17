using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.Subscriptions.GetUserSubscriptions
{
    public record GetUserSubscriptionsQuery(Guid subscriberId) : IQuery<List<UserSubscriptionResponse>>
    {

    }
}
