using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Application.Features.Reservations.GetHostReservationRequests
{
    public record ReservationRequestResponse(string accommodation, ReservationRequest Request)
    {
    }
}