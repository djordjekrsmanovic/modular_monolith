﻿using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Domain.Events
{
    public sealed record ReservationRequestAcceptedDomainEvent(DateTimeSlot Slot, Guid AccommodationId, Guid GuestId, Guid ReservationRequestId, int GuestNumber) : DomainEvent
    {
    }
}
