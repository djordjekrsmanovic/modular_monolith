namespace Booking.Accomodation.Presentation.Contracts
{
    public record EditAccommodationRequest(Guid Id, string Name, string Description, string Street, string City,
        String Country, int MinGuest, int MaxGuest, Double PricePerGuest, List<AdditionalServiceRequest> additionalServices,
        Guid hostId, List<ImageRequest> Images, bool ReservationApprovalRequired)
    {
    }
}
