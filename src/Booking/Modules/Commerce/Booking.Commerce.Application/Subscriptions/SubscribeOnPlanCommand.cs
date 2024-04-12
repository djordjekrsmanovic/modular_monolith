using Booking.BuildingBlocks.Application.CQRS;
using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Application.Subscriptions
{
    public record SubscribeOnPlanCommand(Guid SubscriberId, Guid PlanId, PaymentMethod Method) : ICommand<Guid>
    {
    }
}
