namespace Booking.UserAccess.Application.Features.UserInfo.GetUserInfo
{
    public sealed record UserInfoResponse(Guid Id, string FirstName, string LastName, string Email, string Address, string Phone)
    {
    }
}
