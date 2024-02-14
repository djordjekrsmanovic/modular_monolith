using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Domain;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Events;
using Booking.UserAccess.Domain.Repositories;
using Booking.UserAccess.IntegrationEvents;

namespace Booking.UserAccess.Application.Features.Registration.ConfirmRegistrationRequest
{
    public class RegistrationConfirmedDomainEventHandler : IDomainEventHandler<UserRegistrationConfirmedDomainEvent>
    {
        private IUserAccessUnitOfWork _unitOfWork;
        private IRegistrationRequestRepository _registrationRequestRepository;
        private IUserRepository _userRepository;
        private IEventBus _eventBus;

        public RegistrationConfirmedDomainEventHandler(IUserAccessUnitOfWork unitOfWork,
            IRegistrationRequestRepository registrationRequestRepository,
            IUserRepository userRepository,
            IEventBus eventBus)
        {
            _unitOfWork = unitOfWork;
            _registrationRequestRepository = registrationRequestRepository;
            _userRepository = userRepository;
            _eventBus = eventBus;
        }

        public async Task Handle(UserRegistrationConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            RegistrationRequest request = _registrationRequestRepository.GetByIdAsync(notification.UserRegistrationId).Result;
            User user = User.CreateFromRegistrationRequest(request).Value;
            _userRepository.Add(user);

            switch (user.Roles)
            {
                case var roles when roles.Contains(Role.Host):
                    _eventBus.PublishAsync(new HostRegisteredIntegrationEvent(user.Id));
                    break;

                case var roles when roles.Contains(Role.Guest):
                    _eventBus.PublishAsync(new GuestRegisteredIntegrationEvent(user.Id));
                    break;
                default:
                    throw new InvalidOperationException("Invalid role assigned to user");
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
