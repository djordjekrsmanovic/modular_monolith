using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Accomodation.Application.Features.Guests.DeleteGuest
{
    public sealed record DeleteGuestCommand(Guid GuestId) : ICommand
    {
    }
}
