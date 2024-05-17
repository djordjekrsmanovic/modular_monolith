
using Booking.Accomodation.IntegrationEvents;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.UserAccess.Domain;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Repositories;

namespace Booking.UserAccess.Application.Features.DeleteUser
{
    public class DeleteUserIntegrationEventHandler : IntegrationEventHandler<UserDeletedIntegrationEvent>
    {
        private readonly IUserRepository _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserIntegrationEventHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task Handle(UserDeletedIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            User user = await _userRepository.GetByIdAsync(integrationEvnet.UserId, token);

            user.DeleteUser();

            _unitOfWork.SaveChangesAsync();
        }
    }
}
