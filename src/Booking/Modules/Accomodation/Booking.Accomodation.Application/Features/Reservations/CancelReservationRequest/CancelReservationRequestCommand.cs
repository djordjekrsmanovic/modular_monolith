
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.CancelReservationRequest
{
    public sealed record CancelReservationRequestCommand(Guid Id) : ICommand
    {

    }
}
