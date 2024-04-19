using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Application.Features.SubscriptionPlans.Get;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.Subscriptions.GetUserSubscriptions
{
    internal class GetUserSubscriptionsQueryHandler : IQueryHandler<GetUserSubscriptionsQuery, List<UserSubscriptionResponse>>
    {

        private readonly ISubscriberRepository _subscriberRepository;

        public GetUserSubscriptionsQueryHandler(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public async Task<Result<List<UserSubscriptionResponse>>> Handle(GetUserSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            Subscriber subscriber = await _subscriberRepository.GetAsync(request.subscriberId);

            List<UserSubscriptionResponse> response = subscriber.Subscriptions
                .Where(s => s.Status == SubscriptionStatus.Active || s.Status == SubscriptionStatus.WaitingForApproval)
                .Select(s =>
                    {
                        return new UserSubscriptionResponse(
                            Plan: new SubscriptionPlanResponse(
                                                        Id: s.Plan.Id,
                                                        Name: s.Plan.Name,
                                                        Description: s.Plan.Description,
                                                        Price: s.Plan.Price.ConvertToString(),
                                                        Duration: s.Plan.DurationInMonths,
                                                        AccommodationLimit: s.Plan.AccomodationLimit
                                              ),
                            SubscriptionPeriod: s.SubscriptionPeriod,
                            Status: s.Status
                        );
                    })
                .ToList();

            return Result.Success(response);

        }
    }
}
