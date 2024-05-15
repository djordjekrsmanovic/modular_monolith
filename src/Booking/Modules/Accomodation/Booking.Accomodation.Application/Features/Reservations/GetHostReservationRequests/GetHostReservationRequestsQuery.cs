using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reservations.GetHostReservationRequests
{
    public sealed record GetHostReservationRequestsQuery(Guid HostId) : IQuery<List<ReservationRequestResponse>>
    {
    }
}
