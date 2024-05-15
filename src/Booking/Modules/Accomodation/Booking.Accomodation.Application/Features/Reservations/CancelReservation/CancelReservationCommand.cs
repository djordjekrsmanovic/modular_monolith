using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reservations.CancelReservation
{
    public sealed record CancelReservationCommand(Guid AccommodationId, Guid ReservationId) : ICommand
    {
    }
}
