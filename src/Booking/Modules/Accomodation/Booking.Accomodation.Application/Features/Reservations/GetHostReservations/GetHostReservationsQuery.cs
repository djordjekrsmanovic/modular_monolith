using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.GetHostReservations
{
    public record GetHostReservationsQuery(Guid HostId) : IQuery<List<ReservationResponse>>
    {

    }
}
