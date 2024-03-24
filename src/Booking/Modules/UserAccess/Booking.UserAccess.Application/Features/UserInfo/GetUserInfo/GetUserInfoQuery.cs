using Booking.BuildingBlocks.Application.CQRS;

namespace Booking.UserAccess.Application.Features.UserInfo.GetUserInfo
{
    public sealed record GetUserInfoQuery(Guid Id) : IQuery<UserInfoResponse>
    {
    }
}
