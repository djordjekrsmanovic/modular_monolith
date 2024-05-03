using Booking.Accomodation.Application.Features.Reservations.AcceptReservationRequest;
using Booking.Accomodation.Application.Features.Reservations.CalculateReservationPrice;
using Booking.Accomodation.Application.Features.Reservations.CancelReservation;
using Booking.Accomodation.Application.Features.Reservations.CancelReservationRequest;
using Booking.Accomodation.Application.Features.Reservations.CreateReservation;
using Booking.Accomodation.Application.Features.Reservations.CreateReservationRequest;
using Booking.Accomodation.Application.Features.Reservations.GetGuestReservationRequests;
using Booking.Accomodation.Application.Features.Reservations.GetGuestReservations;
using Booking.Accomodation.Application.Features.Reservations.GetHostReservationRequests;
using Booking.Accomodation.Application.Features.Reservations.GetHostReservations;
using Booking.Accomodation.Presentation.Contracts;
using Booking.BuildingBlocks.Domain.Enums;
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
        [HasPermission(Permission.GuestReservationOperations)]
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

        [HttpPost("requests")]
        [HasPermission(Permission.GuestReservationOperations)]
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

        [HttpGet("requests/host/{id}")]
        [HasPermission(Permission.HostReservationOperations)]
        public async Task<IActionResult> GetHostRequests(Guid id, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new GetHostReservationRequestsQuery(id));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response);
        }

        [HttpGet("requests/guest/{id}")]
        [HasPermission(Permission.GuestReservationOperations)]
        public async Task<IActionResult> GetGuestRequests(Guid id, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new GetGuestReservationRequestsQuery(id));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response);
        }

        [HttpPut("requests/accept/{id}")]
        [HasPermission(Permission.HostReservationOperations)]
        public async Task<IActionResult> AcceptReservationRequest(Guid id, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new AcceptReservationRequestCommand(id));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response);
        }

        [HttpPut("requests/cancel/{id}")]
        [HasPermission(Permission.HostReservationOperations)]
        public async Task<IActionResult> CancelReservationRequest(Guid id, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new CancelReservationRequestCommand(id));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response);
        }

        [HttpPut("cancel/")]
        [HasPermission(Permission.GuestReservationOperations)]
        public async Task<IActionResult> CancelReservation([FromBody] CancelReservationRequest request, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new CancelReservationCommand(request.AccommodationId, request.ReservationId));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response);
        }

        [HttpGet("guest/{id}")]
        [HasPermission(Permission.GuestReservationOperations)]
        public async Task<IActionResult> GetGuestReservations(Guid id, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new GetGuestReservationsQuery(id));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response);
        }

        [HttpGet("host/{id}")]
        [HasPermission(Permission.HostReservationOperations)]
        public async Task<IActionResult> GetHostReservations(Guid id, CancellationToken cancellationToken)
        {
            var response = await Sender.Send(new GetHostReservationsQuery(id));

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response);
        }
    }
}
