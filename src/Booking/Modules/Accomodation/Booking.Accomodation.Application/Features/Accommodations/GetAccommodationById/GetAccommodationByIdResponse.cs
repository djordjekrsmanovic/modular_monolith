using Booking.Accomodation.Application.Features.Accommodations.AddAvailabilityPeriod;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodationById
{
    public record GetAccommodationByIdResponse(Guid Id, string Name, string Description,
        string Address, string Price, List<string> AdditionalServices, Double Raiting, List<ImageResponse> Images,
        List<AvailabilityPeriodResponse> AvailabilityPeriods, List<DateTimeSlot> Reservations, Guid HostId, int MinGuest, int MaxGuest)
    {
    }


}