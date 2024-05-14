using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Reservations.CreateReservation
{
    public sealed record CreateReservationCommand(Guid AccommodationId, Guid GuestId, Double Price, int GuestNumber, DateTime Start, DateTime End) : ICommand
    {
    }
}
