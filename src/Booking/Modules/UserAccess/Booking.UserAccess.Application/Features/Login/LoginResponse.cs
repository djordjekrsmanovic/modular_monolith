namespace Booking.UserAccess.Application.Features.Login
{
    public sealed record LoginResponse(Guid Id, string Jwt, string Role)
    {
    }
}
