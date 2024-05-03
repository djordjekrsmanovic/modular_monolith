using Booking.BuildingBlocks.Application.CQRS;
using Booking.Commerce.Domain.Enums;

namespace Booking.Commerce.Application.Features.Reservations.PayReservation
{
    public record PayReservationCommand(Guid ReservationId, PaymentMethod Method) : ICommand
    {
    }
}
