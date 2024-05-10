using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Commerce.Domain.Entities
{
    public class SubscriptionInvoice : Entity<Guid>
    {
        public Money Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public SubscriptionPayment Payment { get; set; }

        private SubscriptionInvoice() { }

        private SubscriptionInvoice(SubscriptionPayment payment)
        {
            Payment = payment;
            CreatedAt = DateTime.UtcNow;
            Price = payment.Amount;
        }

        public static Result<SubscriptionInvoice> Create(SubscriptionPayment payment)
        {
            return Result.Success(new SubscriptionInvoice(payment));
        }
    }
}
