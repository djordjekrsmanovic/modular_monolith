using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reservations.GetHostReservations
{
    public sealed record GetHostReservationsQuery(Guid HostId) : IQuery<List<ReservationResponse>>
    {

    }
}
