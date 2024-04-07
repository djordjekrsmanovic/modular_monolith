namespace Booking.Accomodation.Application.Features.Accommodations.GetAccommodation
{
    public record AccommodationResponse(Guid Id, string Name, string Description, string Address, string Price, List<string> AdditionalServices, Double Raiting, string image)
    {
    }
}