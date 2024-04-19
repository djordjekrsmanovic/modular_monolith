using Booking.BuildingBlocks.Presentation;
using Booking.Commerce.Application.Features.Subscriptions.GetUserSubscriptions;
using Booking.Commerce.Application.Features.Subscriptions.Payments.ConfirmPayment;
using Booking.Commerce.Application.Features.Subscriptions.Subscribe;
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

        [HttpPost("subscribe")]
        public async Task<IActionResult> SubscribeOnPlan([FromBody] SubscribeOnPlanRequest request, CancellationToken token)
        {
            var response = await Sender.Send(new SubscribeOnPlanCommand(request.SubscriberId, request.PlanId, request.PaymentMethod), token);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            return HandleFailure(response);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserSubscriptions(Guid id, CancellationToken token)
        {

            var response = await Sender.Send(new GetUserSubscriptionsQuery(id), token);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            return HandleFailure(response);
        }

        [HttpPost("confirm-payment")]
        public async Task<IActionResult> ConfirmPayment([FromBody] ConfirmPaymentRequest request, CancellationToken token)
        {
            var response = await Sender.Send(new ConfirmPaymentCommand(request.SubscriptionId, request.PaymentId), token);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return HandleFailure(response);
        }
    }
}
