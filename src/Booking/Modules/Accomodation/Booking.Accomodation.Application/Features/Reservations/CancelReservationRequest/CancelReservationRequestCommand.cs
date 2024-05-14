
using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reservations.CancelReservationRequest
{
    public sealed record CancelReservationRequestCommand(Guid Id) : ICommand
    {

    }
}
