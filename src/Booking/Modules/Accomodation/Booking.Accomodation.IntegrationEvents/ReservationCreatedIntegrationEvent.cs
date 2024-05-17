﻿using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain.Enums;

namespace Booking.AccommodationNS.IntegrationEvents
{
    public sealed record ReservationCreatedIntegrationEvent(Guid ReservationId, double Amount, Currency Currency) : IntegrationEvent
    {

    }
}
