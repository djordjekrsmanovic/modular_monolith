using Booking.Accomodation.Application.Features.Reservations.GetHostReservationRequests;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.GetGuestReservationRequests
{
    public sealed record GetGuestReservationRequestsQuery(Guid GuestId) : IQuery<List<ReservationRequestResponse>>
    {
    }
}
