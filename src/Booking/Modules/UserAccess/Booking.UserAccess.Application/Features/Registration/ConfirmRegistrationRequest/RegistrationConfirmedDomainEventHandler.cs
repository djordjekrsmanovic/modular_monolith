using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Domain;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Events;
using Booking.UserAccess.Domain.Repositories;
using MediatR;

namespace Booking.UserAccess.Application.Features.Registration.ConfirmRegistrationRequest
{
    public class RegistrationConfirmedDomainEventHandler : IDomainEventHandler<UserRegistrationConfirmedDomainEvent>
    {
        private IUnitOfWork _unitOfWork;
        private IRegistrationRequestRepository _registrationRequestRepository;
        private IUserRepository _userRepository;

        public RegistrationConfirmedDomainEventHandler(IUnitOfWork unitOfWork, IRegistrationRequestRepository registrationRequestRepository, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _registrationRequestRepository = registrationRequestRepository;
            _userRepository = userRepository;
        }

        public async Task Handle(UserRegistrationConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            RegistrationRequest request = _registrationRequestRepository.GetByIdAsync(notification.UserRegistrationId).Result;
            User user = User.CreateFromRegistrationRequest(request).Value;
            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
