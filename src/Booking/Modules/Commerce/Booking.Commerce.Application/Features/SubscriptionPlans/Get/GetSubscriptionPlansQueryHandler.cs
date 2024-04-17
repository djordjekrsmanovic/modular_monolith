using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.SubscriptionPlans.Get
{
    internal class GetSubscriptionPlansQueryHandler : IQueryHandler<GetSubscriptionPlansQuery, List<SubscriptionPlanResponse>>
    {
        private readonly ISubscriptionPlanRepository _subscriptionPlanRepository;

        public GetSubscriptionPlansQueryHandler(ISubscriptionPlanRepository subscriptionPlanRepository)
        {
            _subscriptionPlanRepository = subscriptionPlanRepository;
        }
        public async Task<Result<List<SubscriptionPlanResponse>>> Handle(GetSubscriptionPlansQuery request, CancellationToken cancellationToken)
        {
            List<SubscriptionPlan> plans = await _subscriptionPlanRepository.GetAsync();

            return plans.Select(plan => new SubscriptionPlanResponse(
                Id: plan.Id,
                Name: plan.Name,
                Description: plan.Description,
                Price: plan.Price.ConvertToString(),
                Duration: plan.durationInMonths,
                AccommodationLimit: plan.AccomodationLimit
            )).ToList();
        }
    }
}
