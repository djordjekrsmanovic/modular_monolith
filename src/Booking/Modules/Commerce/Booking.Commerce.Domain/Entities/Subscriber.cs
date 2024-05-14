using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Domain.Errors;
using Booking.Commerce.Domain.Events;

namespace Booking.Commerce.Domain.Entities
{
    public class Subscriber : Entity<Guid>
    {
        public List<Subscription> Subscriptions { get; private set; }

        public List<SubscriptionInvoice> Invoices { get; private set; }

        private Subscriber() { }

        private Subscriber(Guid id)
        {
            Id = id;
            Subscriptions = new List<Subscription>();
            Invoices = new List<SubscriptionInvoice>();
        }

        public static Subscriber Create(Guid id)
        {
            Subscriber subscriber = new Subscriber(id);
            return subscriber;
        }

        public Result<Subscription> Subscribe(SubscriptionPlan plan, PaymentMethod paymentMethod)
        {
            if (isAlreadySubscribed(plan))
            {
                return Result.Failure<Subscription>(SubscriptionErrors.UserAlreadySubscribed);
            }

            Subscription subscription = Subscription.Create(plan, Id).Value;
            Subscriptions.Add(subscription);
            this.RaiseDomainEvent(new UserSubscribedDomainEvent(subscription, paymentMethod));
            return Result.Success(subscription);
        }

        private bool isAlreadySubscribed(SubscriptionPlan plan)
        {
            return Subscriptions.Any(subscription => subscription.Plan.Id == plan.Id && subscription.Status == SubscriptionStatus.Active);
        }

        public void AddInvoice(SubscriptionInvoice invoice)
        {
            Invoices.Add(invoice);
        }
    }
}
