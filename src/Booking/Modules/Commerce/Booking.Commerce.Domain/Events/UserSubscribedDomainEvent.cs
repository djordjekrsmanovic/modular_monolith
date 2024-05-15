﻿using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Domain.Events
{
    public sealed record UserSubscribedDomainEvent(Subscription Subscription, PaymentMethod PaymentMethod) : DomainEvent
    {
    }
}
