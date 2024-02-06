using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Entities
{
    public class Subscriber : Entity<Guid>
    {
        public List<Subscription> Subscriptions { get; set; }

        public List<SubscriptionInvoice> Invoices { get; set; }
    }
}
