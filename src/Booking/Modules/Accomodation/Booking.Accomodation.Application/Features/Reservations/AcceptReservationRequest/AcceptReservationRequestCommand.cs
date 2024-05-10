using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.AcceptReservationRequest
{
    public record AcceptReservationRequestCommand(Guid ReservationRequestId) : ICommand
    {
    }
}
