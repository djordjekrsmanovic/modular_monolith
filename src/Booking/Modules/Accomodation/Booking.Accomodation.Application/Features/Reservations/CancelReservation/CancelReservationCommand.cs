using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.CancelReservation
{
    public record CancelReservationCommand(Guid AccommodationId, Guid ReservationId) : ICommand
    {
    }
}
