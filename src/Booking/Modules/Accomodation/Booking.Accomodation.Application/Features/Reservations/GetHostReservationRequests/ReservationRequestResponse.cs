using Booking.AccommodationNS.Domain.Entities;

namespace Booking.Accomodation.Application.Features.Reservations.GetHostReservationRequests
{
    public sealed record ReservationRequestResponse(string accommodation, ReservationRequest Request)
    {
    }
}