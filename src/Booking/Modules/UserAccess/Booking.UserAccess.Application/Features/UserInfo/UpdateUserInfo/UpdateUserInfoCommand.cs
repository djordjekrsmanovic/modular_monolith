using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;

namespace Booking.UserAccess.Application.Features.UserInfo.UpdateUserInfo
{
    public sealed record UpdateUserInfoCommand(Guid Id, string FirstName, string LastName, string Email,
        string Phone, Address Address, string currentPassword, string newPassword) : ICommand<Guid>
    {
    }
}
