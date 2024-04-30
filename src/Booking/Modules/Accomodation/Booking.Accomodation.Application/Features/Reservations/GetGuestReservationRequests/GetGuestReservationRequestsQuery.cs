using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.GetGuestReservationRequests
{
    public record GetGuestReservationRequestsQuery(Guid GuestId) : IQuery<List<ReservationRequest>>
    {
    }
}
