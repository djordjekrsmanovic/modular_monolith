using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.SubscriptionPlans.Get
{
    public sealed record GetSubscriptionPlansQuery : IQuery<List<SubscriptionPlanResponse>>
    {
    }
}
