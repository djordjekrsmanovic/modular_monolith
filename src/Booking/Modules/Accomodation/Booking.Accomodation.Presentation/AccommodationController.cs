using Booking.Accomodation.Application.Features.AccommodationNS.AddAccommodation;
using Booking.Accomodation.Application.Features.Accommodations.GetAccommodation;
using Booking.Accomodation.Application.Features.Accommodations.GetAdditionalServices;
using Booking.Accomodation.Presentation.Contracts;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Booking.Presentation
{

    [Route("api/accommodations")]
    public class AccommodationController : ApiController
    {

        public AccommodationController(ISender sender) : base(sender)
        {

        }

        [HttpPost("")]
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
                .Select(service => AdditionalService.Create(service.Id, service.Name)).ToList();

            AddAccommodationCommand command = new AddAccommodationCommand(request.Name, request.Description, request.Street, request.City,
                request.Country, request.MinGuest, request.MaxGuest, request.PricePerGuest, additionalServices, request.hostId, images);

            Result<Guid> response = await Sender.Send(command, cancellationToken);
            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response.Value);
        }

        [HttpGet("")]
        public async Task<IActionResult> Get([FromQuery] GetAccommodationsQuery query, CancellationToken cancellationToken)
        {

            var response = await Sender.Send(query, cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response.Value);

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
