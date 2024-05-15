namespace Booking.Commerce.Presentation.Contracts
{
    public sealed record ConfirmPaymentRequest(Guid SubscriptionId, Guid PaymentId)
    {
    }
}
