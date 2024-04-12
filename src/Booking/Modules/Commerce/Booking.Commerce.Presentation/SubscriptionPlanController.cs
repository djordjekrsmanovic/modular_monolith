using Booking.BuildingBlocks.Presentation;
using Booking.Commerce.Application.Features.SubscriptionPlans.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Commerce.Presentation
{
    [Route("api/subscriptions/subscription-plans")]
    public class SubscriptionPlanController : ApiController
    {

        public SubscriptionPlanController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken token)
        {
            var response = await Sender.Send(new GetSubscriptionPlansQuery(), token);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            return HandleFailure(response);
        }
    }
}
