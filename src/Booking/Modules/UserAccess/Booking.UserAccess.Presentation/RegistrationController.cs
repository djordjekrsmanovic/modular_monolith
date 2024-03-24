using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel;
using Booking.BuildingBlocks.Presentation;
using Booking.UserAccess.Application.Features.Registration.ConfirmRegistrationRequest;
using Booking.UserAccess.Application.Features.Registration.SubmitRegistrationRequest;
using Booking.UserAccess.Domain.Enums;
using Booking.UserAccess.Presentation.Contracts.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.UserAccess.Presentation
{
    [ApiController]

    public class RegistrationController : ApiController
    {
        public RegistrationController(ISender sender) : base(sender)
        {
        }

        [HttpPost()]
        [Route("api/register")]
        public async Task<IActionResult> SubmitRegistrationRequest([FromBody] RegistrationRequest request,
            CancellationToken cancellationToken)
        {
            RegistrationType registrationType = request.Type == "0" ? RegistrationType.Guest : request.Type == "1" ? RegistrationType.Host : throw new InvalidDataException();

            var command = new RegistrationCommand(request.Email,
                request.Password,
                request.LastName,
                request.FirstName,
                registrationType,
                request.Phone,
                Address.Create(request.Street, request.City, request.Country));

            Result result = await Sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return HandleFailure(result);
        }



        [HttpGet()]
        [Route("api/register/confirm-registration")]
        public async Task<IActionResult> ConfirmRegistration([FromQuery(Name = "confirmation-code")] string ConfirmationCode,
            CancellationToken cancellationToken)
        {
            var command = new ConfirmRegistrationCommand(ConfirmationCode = ConfirmationCode);

            Result result = await Sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return HandleFailure(result);
        }
    }
}
