using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Presentation.Contracts
{
    public record SubscribeOnPlanRequest(Guid SubscriberId, Guid PlanId, PaymentMethod PaymentMethod)
    {
    }
}
