namespace Booking.Commerce.Presentation.Contracts
{
    public record ConfirmPaymentRequest(Guid SubscriptionId, Guid PaymentId)
    {
    }
}
