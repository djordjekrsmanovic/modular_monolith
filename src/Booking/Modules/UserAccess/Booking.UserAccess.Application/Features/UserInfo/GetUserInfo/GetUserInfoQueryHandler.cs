using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Errors;
using Booking.UserAccess.Domain.Repositories;

namespace Booking.UserAccess.Application.Features.UserInfo.GetUserInfo
{
    internal class GetUserInfoQueryHandler : IQueryHandler<GetUserInfoQuery, UserInfoResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserInfoQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<UserInfoResponse>> Handle(GetUserInfoQuery request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);

            if (user == null)
            {
                return Result.Failure<UserInfoResponse>(UserErrors.UserWithProvidedIdNotExist);
            }

            UserInfoResponse response = new UserInfoResponse(user.Id, user.FirstName, user.LastName, user.Email, user.Address.ConvertToString(), user.Phone);

            return Result.Success(response);
        }
    }
}
