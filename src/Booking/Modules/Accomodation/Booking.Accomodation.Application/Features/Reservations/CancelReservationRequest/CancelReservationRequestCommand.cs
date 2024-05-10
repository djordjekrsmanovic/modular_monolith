
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.CancelReservationRequest
{
    public record CancelReservationRequestCommand(Guid Id) : ICommand
    {

    }
}
