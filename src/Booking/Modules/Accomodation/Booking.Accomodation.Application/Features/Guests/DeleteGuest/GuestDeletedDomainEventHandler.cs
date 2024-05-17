using Booking.Accomodation.Domain.Events;
using Booking.Accomodation.IntegrationEvents;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Guests.DeleteGuest
{
    public class GuestDeletedDomainEventHandler : IDomainEventHandler<GuestDeletedDomainEvent>
    {

        private readonly IEventBus _eventBus;

        public GuestDeletedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(GuestDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _eventBus.PublishAsync(new UserDeletedIntegrationEvent(notification.GuestId));
        }
    }
}
