using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Repositories;
using MediatR;

namespace Booking.UserAccess.Application.Features.Login
{
    internal class LoginCommandHandler : ICommandHandler<LoginCommand, string>
    {

        private IUserRepository _userRepository;

        private IJwtProvider _jwtProvider;

        public LoginCommandHandler(IUserRepository userRepository,IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        async Task<Result<string>> IRequestHandler<LoginCommand, Result<string>>.Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            
            User user = await _userRepository.GetByEmailAsync(request.username, cancellationToken);

            if (user is null)
            {
                return Result.Failure<string>(new Error("User.WrongCredentials", "Invalid user credentials"));
            }

            string token = _jwtProvider.Generate(user);

            return Result.Success<string>(token);
        }
    }
}
