using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.Commerce.Application.Features.Reservations.GetReservationsPaymentStatus
{
    public record GetReservationPaymentStatusQuery(Guid ReservationId) : IQuery<ReservationPaymentStatusResponse>
    {
    }
}
