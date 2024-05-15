using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Presentation.Contracts
{
    public sealed record SubscribeOnPlanRequest(Guid SubscriberId, Guid PlanId, PaymentMethod PaymentMethod)
    {
    }
}
