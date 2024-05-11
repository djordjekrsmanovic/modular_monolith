namespace Booking.UserAccess.Presentation.Contracts.Request
{
    public sealed record RegistrationRequest(
        string Email,
        string Password,
        string FirstName,
        string LastName,
        string Type,
        string Phone,
        string Street,
        string Country,
        string City
     );
}
