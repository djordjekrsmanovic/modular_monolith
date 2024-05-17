using Booking.Accomodation.Domain.Events;
using Booking.Accomodation.IntegrationEvents;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Hosts.DeleteHost
{
    public class HostDeletedDomainEventHandler : IDomainEventHandler<HostDeletedDomainEvent>
    {
        private readonly IEventBus _eventBus;

        public HostDeletedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(HostDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _eventBus.PublishAsync(new UserDeletedIntegrationEvent(notification.HostId));
        }


    }
}
