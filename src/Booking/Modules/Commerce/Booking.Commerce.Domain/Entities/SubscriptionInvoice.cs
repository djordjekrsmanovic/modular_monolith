using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel;

namespace Booking.Commerce.Domain.Entities
{
    public class SubscriptionInvoice : Entity<Guid>
    {
        public Subscription Subscription { get; set; }

        public Money Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public Payment Payment { get; set; }
    }
}
