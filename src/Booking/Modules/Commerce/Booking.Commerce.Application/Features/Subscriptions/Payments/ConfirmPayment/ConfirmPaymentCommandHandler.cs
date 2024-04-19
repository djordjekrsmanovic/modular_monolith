using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Errors;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Subscriptions.Payments.ConfirmPayment
{
    internal class ConfirmPaymentCommandHandler : ICommandHandler<ConfirmPaymentCommand>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConfirmPaymentCommandHandler(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ConfirmPaymentCommand request, CancellationToken cancellationToken)
        {
            Subscription subscription = await _subscriptionRepository.GetAsync(request.SubscriptionId);

            if (subscription is null)
            {
                return Result.Failure(SubscriptionErrors.SubscriptionNotExist);
            }

            var subscriptionResponse = subscription.ConfirmPayment(request.PaymentId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return subscriptionResponse;
        }
    }
}
