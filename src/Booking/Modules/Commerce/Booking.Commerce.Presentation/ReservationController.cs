using Booking.BuildingBlocks.Presentation;
using Booking.Commerce.Application.Features.Reservations.CancelPayment;
using Booking.Commerce.Application.Features.Reservations.ConfirmPayment;
using Booking.Commerce.Application.Features.Reservations.GetReservationsPaymentStatus;
using Booking.Commerce.Application.Features.Reservations.PayReservation;
using Booking.Commerce.Presentation.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Commerce.Presentation
{
    [Route("api/commerce/reservations")]
    public class ReservationController : ApiController
    {
        public ReservationController(ISender sender) : base(sender)
        {

        }

        [HttpGet("payment-status/{id}")]
        public async Task<IActionResult> GetReservationPaymentStatus(Guid id, CancellationToken token)
        {
            var response = await Sender.Send(new GetReservationPaymentStatusQuery(id), token);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            return HandleFailure(response);
        }

        [HttpPost("execute-payment")]
        public async Task<IActionResult> ExecutePayment([FromBody] PayReservationRequest request, CancellationToken token)
        {
            var response = await Sender.Send(new PayReservationCommand(request.ReservationId, request.Method), token);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return HandleFailure(response);
        }

        [HttpPost("confirm-payment")]
        public async Task<IActionResult> ConfirmPayment([FromBody] PayReservationRequest request, CancellationToken token)
        {
            var response = await Sender.Send(new ConfirmPaymentCommand(request.ReservationId), token);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return HandleFailure(response);
        }

        [HttpPost("cancel-payment")]
        public async Task<IActionResult> CancelPayment([FromBody] CancelPaymentRequest request, CancellationToken token)
        {
            var response = await Sender.Send(new CancelPaymentCommand(request.ReservationId), token);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return HandleFailure(response);
        }


    }
}
