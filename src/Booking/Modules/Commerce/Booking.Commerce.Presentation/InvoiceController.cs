using Booking.BuildingBlocks.Presentation;
using Booking.Commerce.Application.Features.Invoices.ReservationInvoices;
using Booking.Commerce.Application.Features.Invoices.SubscriptionInvoices;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Commerce.Presentation
{

    [Route("api/invoices")]
    public class InvoiceController : ApiController
    {
        public InvoiceController(ISender sender) : base(sender)
        {
        }

        [HttpGet("payer/{id}")]
        public async Task<IActionResult> GetPayerInvoices(Guid id, CancellationToken token)
        {
            var response = await Sender.Send(new GetPayerReservationInvoicesQuery(id), token);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            return HandleFailure(response);
        }

        [HttpGet("subscriber/{id}")]
        public async Task<IActionResult> GetSubscriberInvoices(Guid id, CancellationToken token)
        {
            var response = await Sender.Send(new GetSubscriberInvoicesQuery(id), token);
            if (response.IsSuccess)
            {
                return Ok(response.Value);
            }
            return HandleFailure(response);
        }
    }
}
