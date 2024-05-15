using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reservations.AcceptReservationRequest
{
    public record AcceptReservationRequestCommand(Guid ReservationRequestId) : ICommand
    {
    }
}
