using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Events;
using Booking.Commerce.IntegrationEvents;

namespace Booking.Commerce.Application.Features.Subscriptions.Payments.ConfirmPayment
{
    internal class PaymentConfirmedDomainEventHandler : IDomainEventHandler<PaymentConfirmedDomainEvent>
    {
        private readonly IEventBus _eventBus;

        public PaymentConfirmedDomainEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(PaymentConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _eventBus.PublishAsync(
                new SubscribedOnPlanIntegrationEvent(
                    notification.SubscriberId,
                    notification.AccommodationLimit,
                    notification.Start.AddMonths(notification.DurationInMonths)
                ),
                cancellationToken
            );

        }
    }
}
