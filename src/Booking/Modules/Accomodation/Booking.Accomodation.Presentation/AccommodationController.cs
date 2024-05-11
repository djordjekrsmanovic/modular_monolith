using Booking.AccommodationNS.Domain.Entities;
using Booking.Accomodation.Application.Features.AccommodationNS.AddAccommodation;
using Booking.Accomodation.Application.Features.Accommodations.AddAvailabilityPeriod;
using Booking.Accomodation.Application.Features.Accommodations.DeleteAvailabilityPeriod;
using Booking.Accomodation.Application.Features.Accommodations.EditAccommodation;
using Booking.Accomodation.Application.Features.Accommodations.GetAccommodation;
using Booking.Accomodation.Application.Features.Accommodations.GetAccommodationAvailabilityPeriod;
using Booking.Accomodation.Application.Features.Accommodations.GetAccommodationById;
using Booking.Accomodation.Application.Features.Accommodations.GetAdditionalServices;
using Booking.Accomodation.Application.Features.Accommodations.GetHostAccommodations;
using Booking.Accomodation.Presentation.Contracts;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;
using Booking.BuildingBlocks.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.AccommodationNS.Presentation
{

    [Route("api/accommodations")]
    public class AccommodationController : ApiController
    {

        public AccommodationController(ISender sender) : base(sender)
        {

        }

        [HttpPost("")]
        [HasPermission(Permission.HostAccommodationOperations)]
        public async Task<IActionResult> AddAccommodation([FromBody] AddAccommodationRequest request, CancellationToken cancellationToken)
        {


            List<Result<Image>> createImagesResponse = request.Images.Select(image =>
            {
                return Image.Create(image.Name, image.Extension, image.Content, request.hostId, image.Hash);
            }).ToList();

            Result<Image> failedPhoto = createImagesResponse.FirstOrDefault(photo => photo.IsFailure);
            if (failedPhoto != null)
            {
                return HandleFailure(failedPhoto);
            }

            List<Image> images = createImagesResponse.Select(photo => photo.Value).ToList();

            List<AdditionalService> additionalServices = request.additionalServices
                .Where(service => service.Selected).Select(service => AdditionalService.Create(service.Id, service.Name)).ToList();

            AddAccommodationCommand command = new AddAccommodationCommand(request.Name, request.Description, request.Street, request.City,
                request.Country, request.MinGuest, request.MaxGuest, request.PricePerGuest, additionalServices, request.hostId, images, request.ReservationApprovalRequired);

            Result<Guid> response = await Sender.Send(command, cancellationToken);
            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response.Value);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAccommodations([FromQuery] GetAccommodationsQuery query, CancellationToken cancellationToken)
        {

            var response = await Sender.Send(query, cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response.Value);

        }

        [HttpGet("host/{id}")]
        public async Task<IActionResult> GetHostAccommodations(Guid id, CancellationToken cancellationToken)
        {

            var response = await Sender.Send(new GetHostAccommodationsQuery(id), cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response.Value);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccommodationById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetAccommodationByIdQuery(id); // Assuming you have a query for retrieving accommodation by ID
            var response = await Sender.Send(query, cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response.Value);
        }

        [HttpPut("")]
        [HasPermission(Permission.HostAccommodationOperations)]
        public async Task<IActionResult> UpdateAccommodation([FromBody] EditAccommodationRequest request, CancellationToken cancellationToken)
        {
            List<Result<Image>> createImagesResponse = request.Images.Select(image =>
            {
                return Image.Create(image.Name, image.Extension, image.Content, request.hostId, image.Hash);
            }).ToList();

            Result<Image> failedPhoto = createImagesResponse.FirstOrDefault(photo => photo.IsFailure);
            if (failedPhoto != null)
            {
                return HandleFailure(failedPhoto);
            }

            List<Image> images = createImagesResponse.Select(photo => photo.Value).ToList();

            List<AdditionalService> additionalServices = request.additionalServices
                .Where(service => service.Selected).Select(service => AdditionalService.Create(service.Id, service.Name)).ToList();

            EditAccommodationCommand command = new EditAccommodationCommand(request.Id, request.Name, request.Description, request.Street, request.City,
                request.Country, request.MinGuest, request.MaxGuest, request.PricePerGuest, additionalServices, request.hostId, images, request.ReservationApprovalRequired);

            var response = await Sender.Send(command, cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response.Value);
        }


        [HttpPost("add-availability-period")]
        [HasPermission(Permission.HostAccommodationOperations)]
        public async Task<IActionResult> AddAvailabilityPeriod([FromBody] AddAvailabilityPeriodRequest request, CancellationToken cancellationToken)
        {
            var command = new AddAvailabilityPeriodCommand(request.AccommodationId, request.Start, request.End, request.PricePerGuest);
            var response = await Sender.Send(command, cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response.Value);
        }


        [HttpPost("{id}/get-availability-period")]
        public async Task<IActionResult> GetAccommodationAvailabilityPeriod(Guid accommodationId, CancellationToken cancellationToken)
        {
            var command = new GetAccommodationAvailabilityPeriodQuery(accommodationId);
            var response = await Sender.Send(command, cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response.Value);
        }

        [HttpPost("delete-availability-period")]
        [HasPermission(Permission.HostAccommodationOperations)]
        public async Task<IActionResult> DeleteAccommodationAvailabilityPeriod([FromBody] DeleteAvailabilityPeriodRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteAvailabilityPeriodCommand(request.AccommodationId, request.AvailabilityPeriodId);
            var response = await Sender.Send(command, cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response);
        }




        [HttpGet("additional-services")]
        public async Task<IActionResult> GetAdditionalServices(CancellationToken cancellationToken)
        {

            var response = await Sender.Send(new GetAdditionalServicesQuery(), cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response.Value);

        }

    }
}
