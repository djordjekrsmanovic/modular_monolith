﻿using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.GetHostReservationRequests
{
    public sealed record GetHostReservationRequestsQuery(Guid HostId) : IQuery<List<ReservationRequestResponse>>
    {
    }
}
