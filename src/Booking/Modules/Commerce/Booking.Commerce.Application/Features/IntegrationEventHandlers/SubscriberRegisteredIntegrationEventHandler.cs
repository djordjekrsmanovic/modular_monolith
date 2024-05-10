using Booking.BuildingBlocks.Application.EventBus;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;
using Booking.UserAccess.IntegrationEvents.Commerce;

namespace Booking.Commerce.Application.Features.IntegrationEventHandlers
{
    public class SubscriberRegisteredIntegrationEventHandler : IntegrationEventHandler<SubscriberRegisteredIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriberRegisteredIntegrationEventHandler(IUnitOfWork unitOfWork, ISubscriberRepository subscriberRepository)
        {
            _unitOfWork = unitOfWork;
            _subscriberRepository = subscriberRepository;
        }

        public override async Task Handle(SubscriberRegisteredIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Subscriber subscriber = Subscriber.Create(integrationEvnet.HostId);

            _subscriberRepository.Add(subscriber);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
