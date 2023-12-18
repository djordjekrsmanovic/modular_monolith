using Booking.UserAccess.Domain.Entities;


namespace Booking.UserAccess.Application.Abstractions
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
