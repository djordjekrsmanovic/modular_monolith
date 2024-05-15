using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.AccommodationNS.Application.Features.Reservations.CreateReservationRequest
{
    public sealed record CreateReservationRequestCommand(Guid AccommodationId, Guid GuestId, string Messsage, int GuestNumber, DateTime Start, DateTime End) : ICommand
    {
    }
}
