﻿using Booking.Accomodation.Application.Features.Reservations.GetHostReservations;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.GetGuestReservations
{
    public sealed record GetGuestReservationsQuery(Guid GuestId) : IQuery<List<ReservationResponse>>
    {
    }
}
