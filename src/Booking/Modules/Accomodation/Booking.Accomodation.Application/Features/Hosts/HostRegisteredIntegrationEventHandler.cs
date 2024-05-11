using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.UserAccess.IntegrationEvents.Accomodation;
using Booking.UserAccess.IntegrationEvents.Commerce;

namespace Booking.Accomodation.Application.Features.Hosts
{
    public class HostRegisteredIntegrationEventHandler : IntegrationEventHandler<HostRegisteredIntegrationEvent>
    {
        private readonly IHostRepository _hostRepository;
        private readonly IUnitOfWork _unitOfWork;

        private readonly IEventBus _eventBus;

        public HostRegisteredIntegrationEventHandler(IHostRepository hostRepository,
            IUnitOfWork unitOfWork,
            IEventBus eventBus)
        {
            _hostRepository = hostRepository;
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;
        }

        public override async Task Handle(HostRegisteredIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Host host = Host.Create(integrationEvnet.HostId);

            _hostRepository.Add(host);

            await _eventBus.PublishAsync(new SubscriberRegisteredIntegrationEvent(host.Id), token);

            await _unitOfWork.SaveChangesAsync(token);

        }
    }
}
