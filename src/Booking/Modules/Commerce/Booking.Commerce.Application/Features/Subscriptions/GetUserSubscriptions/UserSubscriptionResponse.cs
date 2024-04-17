using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Application.Features.SubscriptionPlans.Get;
using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Application.Features.Subscriptions.GetUserSubscriptions
{
    public record UserSubscriptionResponse(SubscriptionPlanResponse Plan, DateTimeSlot SubscriptionPeriod, SubscriptionStatus Status)
    {

    }
}
