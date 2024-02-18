using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;
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
        private IEventBus _bus;



        public RegistrationCommandHandler(IUserRepository userRepository,
            IRegistrationRequestRepository registrationRequestRepository,
            IUnitOfWork unitOfWork,
            IEventBus bus)
        {
            _userRepository = userRepository;
            _registrationRequestRepository = registrationRequestRepository;
            _unitOfWork = unitOfWork;
            _bus = bus;
        }

        public async Task<Result<Guid>> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {

            if (!_userRepository.IsEmailUniqueAsync(request.Email).Result)
            {
                return Result.Failure<Guid>(UserErrors.EmailNotUniqueError);
            }

            RegistrationRequest registrationRequest = RegistrationRequest.Create(request.Email,
                 request.FirstName,
                 request.LastName,
                 request.Password,
                 request.Type).Value;


            _registrationRequestRepository.Add(registrationRequest);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(registrationRequest.Id);

        }

    }
}
