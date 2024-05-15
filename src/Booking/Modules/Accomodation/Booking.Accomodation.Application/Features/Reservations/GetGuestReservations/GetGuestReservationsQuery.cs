using Booking.AccommodationNS.Application.Features.Reservations.GetHostReservations;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reservations.GetGuestReservations
{
    public sealed record GetGuestReservationsQuery(Guid GuestId) : IQuery<List<ReservationResponse>>
    {
    }
}
