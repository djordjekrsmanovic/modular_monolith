using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;
using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Repositories;

namespace Booking.UserAccess.Application.Features.Login
{
    internal class LoginCommandHandler : ICommandHandler<LoginCommand, LoginResponse>
    {

        private IUserRepository _userRepository;

        private IJwtProvider _jwtProvider;

        private ICryptograpyProvider _cryptograpyProvider;

        public LoginCommandHandler(IUserRepository userRepository, IJwtProvider jwtProvider, ICryptograpyProvider cryptograpyProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
            _cryptograpyProvider = cryptograpyProvider;
        }

        public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByEmailAsync(request.username, cancellationToken);

            if (user is null)
            {
                return Result.Failure<LoginResponse>(new Error("User.WrongCredentials", "Invalid user credentials", ErrorType.Unauthorized));
            }

            if (!user.Password.Equals(_cryptograpyProvider.HashPassword(request.password)))
            {
                return Result.Failure<LoginResponse>(new Error("User.WrongCredentials", "Invalid user credentials", ErrorType.Unauthorized));
            }

            string token = _jwtProvider.Generate(user);

            LoginResponse response = new LoginResponse(user.Id, token, user.Roles.FirstOrDefault().Name);

            return Result.Success(response);
        }
    }
}
