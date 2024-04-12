using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Events;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Subscriptions.Subscribe
{
    internal class UserSubscribedDomainEventHandler : IDomainEventHandler<UserSubscribedDomainEvent>
    {

        private readonly IPaymentRepository paymentRepository;

        private readonly IUnitOfWork _unitOfWork;

        public UserSubscribedDomainEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UserSubscribedDomainEvent notification, CancellationToken cancellationToken)
        {
            Payment payment = Payment.Create(notification.Subscription.Plan.Price, notification.PaymentMethod, notification.Subscription.Id).Value;
            notification.Subscription.AddPayment(payment);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
