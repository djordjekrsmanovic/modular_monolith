using Booking.Accomodation.Application.Features.Reservations.CalculateReservationPrice;
using Booking.Accomodation.Application.Features.Reservations.CreateReservation;
using Booking.Accomodation.Application.Features.Reservations.CreateReservationRequest;
using Booking.Accomodation.Presentation.Contracts;
using Booking.BuildingBlocks.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Accomodation.Presentation
{
    [Route("api/reservations")]
    public class ReservationController : ApiController
    {
        public ReservationController(ISender sender) : base(sender)
        {
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequest request, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new CreateReservationCommand(request.AccommodationId, request.GuestId,
                request.Price, request.GuestNumber, request.Start, request.End), cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response);
        }

        [HttpPost("calculate-price")]
        public async Task<IActionResult> CalculatePrice([FromBody] CalculateReservationPriceRequest request, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new CalculateReservationPriceCommand(request.AccommodationId, request.Start, request.End, request.GuestNumber), cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response);
        }

        [HttpPost("request")]
        public async Task<IActionResult> CreateReservationRequest([FromBody] CreateReservationRequestRequest request, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new CreateReservationRequestCommand(request.AccommodationId, request.GuestId,
                request.Message, request.GuestNumber, request.Start, request.End), cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response);
        }
    }
}
