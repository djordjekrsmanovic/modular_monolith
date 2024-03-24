namespace Booking.UserAccess.Presentation.Contracts.Request
{
    public sealed record UpdateUserInfoRequest(Guid Id, string FirstName, string LastName, string Email,
        string Phone, string Country, string City,
        string Street, string PreviousPassword, string NewPassword)
    {
    }
}
