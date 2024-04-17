using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.SubscriptionPlans.Get
{
    public record GetSubscriptionPlansQuery : IQuery<List<SubscriptionPlanResponse>>
    {
    }
}
