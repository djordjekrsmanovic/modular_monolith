using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Entities
{
    public class Subscriber : Entity<Guid>
    {
        public Guid HostId { get; set; }
        public List<Subscription> Subscriptions { get; set; }

        public List<SubscriptionInvoice> Invoices { get; set; }

        private Subscriber(Guid id)
        {
            HostId = Guid.NewGuid();
            Id = Guid.NewGuid();
            Subscriptions = new List<Subscription>();
            Invoices = new List<SubscriptionInvoice>();
        }

        public static Subscriber Create(Guid Id)
        {
            Subscriber subscriber = new Subscriber(Id);
            return subscriber;
        }
    }
}
