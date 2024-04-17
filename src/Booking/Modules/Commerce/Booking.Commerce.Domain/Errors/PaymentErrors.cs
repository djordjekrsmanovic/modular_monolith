using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Errors
{
    public class PaymentErrors
    {
        public static readonly Error InvalidPaymentState = new("Payment.InvalidState", "Unable to confirm payment!");
        public static readonly Error PaymentNotExist = new("Payment.NotExist", "Payment with provided identifier does not exist");
    }
}
