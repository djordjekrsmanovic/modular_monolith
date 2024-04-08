using Booking.Accomodation.Domain.ValueObjects;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodationById
{
    public record GetAccommodationByIdResponse(Guid Id, string Name, string Description,
        string Address, string Price, List<string> AdditionalServices, Double Raiting, List<string> Images,
        List<DateTimeSlot> AvailabilityPeriods, List<DateTimeSlot> Reservations, Guid HostId)
    {
    }


}