using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Errors;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Subscriptions
{
    internal class SubscribeOnPlanCommandHandler : ICommandHandler<SubscribeOnPlanCommand, Guid>
    {

        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;

        private readonly ISubscriberRepository _subscriberRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscribeOnPlanCommandHandler(ISubscriptionPlanRepository subscriptionPlanRepository,
            ISubscriberRepository subscriberRepository,
            IUnitOfWork unitOfWork,
            ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionPlanRepository = subscriptionPlanRepository;
            _subscriberRepository = subscriberRepository;
            _unitOfWork = unitOfWork;
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<Result<Guid>> Handle(SubscribeOnPlanCommand request, CancellationToken cancellationToken)
        {
            SubscriptionPlan subscriptionPlan = await _subscriptionPlanRepository.GetAsync(request.PlanId);

            if (subscriptionPlan is null)
            {
                return Result.Failure<Guid>(SubscriptionPlanErrors.SubscriptionPlanNotExist);
            }

            Subscriber subscriber = await _subscriberRepository.GetAsync(request.SubscriberId);

            if (subscriber is null)
            {
                return Result.Failure<Guid>(SubscriberErrors.SubscriberNotExist);
            }
            var subscribeResponse = subscriber.Subscribe(subscriptionPlan, request.Method);

            if (subscribeResponse.IsFailure)
            {
                return Result.Failure<Guid>(subscribeResponse.Error);
            }

            await _subscriptionRepository.Add(subscribeResponse.Value);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success(subscribeResponse.Value.Id);
        }
    }
}
