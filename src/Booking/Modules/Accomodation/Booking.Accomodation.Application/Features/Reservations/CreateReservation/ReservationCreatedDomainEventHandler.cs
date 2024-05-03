using Booking.Accomodation.Domain.Events;
using Booking.Booking.IntegrationEvents;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.CreateReservation
{
    internal class ReservationCreatedDomainEventHandler : IDomainEventHandler<ReservationCreatedDomainEvent>
    {

        private readonly IEventBus _eventBus;

        public ReservationCreatedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(ReservationCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _eventBus.PublishAsync(new ReservationCreatedIntegrationEvent(notification.ReservationId, notification.Price.Ammount, notification.Price.Currency));
        }
    }
}
