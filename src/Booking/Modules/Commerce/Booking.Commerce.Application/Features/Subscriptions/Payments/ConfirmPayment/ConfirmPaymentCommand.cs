using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.Subscriptions.Payments.ConfirmPayment
{
    public record ConfirmPaymentCommand(Guid SubscriptionId, Guid PaymentId) : ICommand
    {
    }
}
