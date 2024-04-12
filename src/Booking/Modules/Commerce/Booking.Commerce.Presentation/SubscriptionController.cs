using Booking.BuildingBlocks.Presentation;
using Booking.Commerce.Application.Features.Subscriptions.Subscribe;
using Booking.Commerce.Domain.Enums;
using Booking.Commerce.Presentation.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Commerce.Presentation
{
    [Route("api/subscriptions")]
    public class SubscriptionController : ApiController
    {

        public SubscriptionController(ISender sender) : base(sender)
        {
        }

        [HttpPost]
        public async Task<IActionResult> SubscribeOnPlan([FromBody] SubscribeOnPlan request, CancellationToken token)
        {
            var response = await Sender.Send(new SubscribeOnPlanCommand(Guid.Parse("76D6A5B0-C646-47AE-376B-08DC4B6357B2"), Guid.Parse("9B268827-F2E8-404F-908B-2A15F00A987F"), PaymentMethod.CreditCard), token);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            return HandleFailure(response);
        }
    }
}
