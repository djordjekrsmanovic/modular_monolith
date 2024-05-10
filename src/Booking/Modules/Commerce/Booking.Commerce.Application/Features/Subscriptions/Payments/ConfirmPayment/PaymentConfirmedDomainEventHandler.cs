using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Events;
using Booking.Commerce.Domain.Repositories;
using Booking.Commerce.IntegrationEvents;

namespace Booking.Commerce.Application.Features.Subscriptions.Payments.ConfirmPayment
{
    internal class PaymentConfirmedDomainEventHandler : IDomainEventHandler<SubscriptionPaymentConfirmedDomainEvent>
    {
        private readonly IEventBus _eventBus;

        private readonly ISubscriberRepository _subscriberRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ISubscriptionInvoiceRepository _invoiceRepository;

        public PaymentConfirmedDomainEventHandler(IEventBus eventBus, ISubscriberRepository subscriberRepository, IUnitOfWork unitOfWork, ISubscriptionInvoiceRepository invoiceRepository)
        {
            _eventBus = eventBus;
            _subscriberRepository = subscriberRepository;
            _unitOfWork = unitOfWork;
            _invoiceRepository = invoiceRepository;
        }

        public async Task Handle(SubscriptionPaymentConfirmedDomainEvent notification, CancellationToken cancellationToken)
        {

            //create subscription invoice
            var subscriber = await _subscriberRepository.GetAsync(notification.SubscriberId);
            var invoice = SubscriptionInvoice.Create(notification.Payment).Value;
            subscriber.AddInvoice(invoice);

            await _invoiceRepository.Add(invoice);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            //publish integration event
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
