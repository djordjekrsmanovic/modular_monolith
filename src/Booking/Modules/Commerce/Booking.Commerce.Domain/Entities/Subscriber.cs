﻿using Booking.BuildingBlocks.Domain;

namespace Booking.Commerce.Domain.Entities
{
    public class Subscriber : Entity<Guid>
    {
        public List<Subscription> Subscriptions { get; set; }

        public List<SubscriptionInvoice> Invoices { get; set; }

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
    }
}
