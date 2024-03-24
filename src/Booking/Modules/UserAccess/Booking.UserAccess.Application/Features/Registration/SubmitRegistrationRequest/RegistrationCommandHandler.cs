using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Domain;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Errors;
using Booking.UserAccess.Domain.Repositories;

namespace Booking.UserAccess.Application.Features.Registration.SubmitRegistrationRequest
{
    internal class RegistrationCommandHandler : ICommandHandler<RegistrationCommand, Guid>
    {
        private IUserRepository _userRepository;
        private IRegistrationRequestRepository _registrationRequestRepository;
        private IUnitOfWork _unitOfWork;
        private ICryptograpyProvider _cryptograpyProvider;

        public RegistrationCommandHandler(IUserRepository userRepository,
            IRegistrationRequestRepository registrationRequestRepository,
            IUnitOfWork unitOfWork,
            ICryptograpyProvider cryptograpyProvider)
        {
            _userRepository = userRepository;
            _registrationRequestRepository = registrationRequestRepository;
            _unitOfWork = unitOfWork;
            _cryptograpyProvider = cryptograpyProvider;

        }

        public async Task<Result<Guid>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {

            if (!_userRepository.IsEmailUniqueAsync(request.Email).Result)
            {
                return Result.Failure<Guid>(UserErrors.EmailNotUniqueError);
            }

            string hashedPassword = _cryptograpyProvider.HashPassword(request.Password);

            RegistrationRequest registrationRequest = RegistrationRequest.Create(request.Email,
                 request.FirstName,
                 request.LastName,
                 hashedPassword,
                 request.Type,
                 request.Phone,
                 request.Address).Value;


            _registrationRequestRepository.Add(registrationRequest);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(registrationRequest.Id);

        }

    }
}
