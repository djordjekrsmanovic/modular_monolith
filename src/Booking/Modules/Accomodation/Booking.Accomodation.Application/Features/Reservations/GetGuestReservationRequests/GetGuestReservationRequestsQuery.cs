using Booking.AccommodationNS.Application.Features.Reservations.GetHostReservationRequests;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reservations.GetGuestReservationRequests
{
    public sealed record GetGuestReservationRequestsQuery(Guid GuestId) : IQuery<List<ReservationRequestResponse>>
    {
    }
}
