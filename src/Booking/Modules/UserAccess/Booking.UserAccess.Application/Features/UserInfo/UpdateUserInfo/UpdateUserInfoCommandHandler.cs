using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Domain;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Errors;
using Booking.UserAccess.Domain.Repositories;
using MediatR;

namespace Booking.UserAccess.Application.Features.UserInfo.UpdateUserInfo
{
    internal class UpdateUserInfoCommandHandler : ICommandHandler<UpdateUserInfoCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptograpyProvider _cryptograpyProvider;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserInfoCommandHandler(IUserRepository userRepository, ICryptograpyProvider cryptograpyProvider, IUnitOfWork unitOfWork)
        {
            _cryptograpyProvider = cryptograpyProvider;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        async Task<Result<Guid>> IRequestHandler<UpdateUserInfoCommand, Result<Guid>>.Handle(UpdateUserInfoCommand request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByIdAsync(request.Id, cancellationToken);
            if (user == null)
            {
                return Result.Failure<Guid>(UserErrors.UserWithProvidedIdNotExist);
            }

            if (!user.Email.Equals(request.Email))
            {
                if (!isEmailUniqu(request.Email, cancellationToken).Result)
                {
                    return Result.Failure<Guid>(UserErrors.EmailNotUniqueError);
                }
            }

            Result<Guid> operationResult = user.UpdateUser(request.FirstName, request.LastName, request.Phone,
                request.Email, request.Address, _cryptograpyProvider.HashPassword(request.currentPassword),
                _cryptograpyProvider.HashPassword(request.newPassword));

            await _unitOfWork.SaveChangesAsync();

            return operationResult;

        }

        private async Task<bool> isEmailUniqu(string email, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetByEmailAsync(email, cancellationToken);
            return user != null;
        }
    }
}
