﻿using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Events
{
    public sealed record SubscriptionPaymentConfirmedDomainEvent(SubscriptionPayment Payment, DateTime Start, int DurationInMonths, int AccommodationLimit, Guid SubscriberId) : DomainEvent
    {
    }
}
