namespace Booking.UserAccess.Presentation.Contracts.Request
{
    public sealed record LoginRequest(string email, string password)
    {
    }
}
