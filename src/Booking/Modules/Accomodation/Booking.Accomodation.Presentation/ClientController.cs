using Booking.Accomodation.Application.Features.Guests.DeleteGuest;
using Booking.Accomodation.Application.Features.Hosts.DeleteHost;
using Booking.Accomodation.Presentation.Contracts;
using Booking.BuildingBlocks.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Accomodation.Presentation
{
    [Route("api/clients")]
    public class ClientController : ApiController
    {
        public ClientController(ISender sender) : base(sender)
        {
        }

        [HttpPost("delete-guest")]
        public async Task<IActionResult> CreateReservation([FromBody] DeleteClientRequest request, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new DeleteGuestCommand(request.Id));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response);
        }

        [HttpPost("delete-host")]
        public async Task<IActionResult> DeleteHost([FromBody] DeleteClientRequest request, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new DeleteHostCommand(request.Id));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response);
        }
    }
}
