using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Presentation;
using Booking.UserAccess.Application.Features.Login;
using Booking.UserAccess.Application.Features.Registration.ConfirmRegistrationRequest;
using Booking.UserAccess.Application.Features.Registration.SubmitRegistrationRequest;
using Booking.UserAccess.Presentation.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Presentation
{

    [Route("/register")]
    public class RegistrationController : ApiController
    {
        public RegistrationController(ISender sender) : base(sender)
        {
        }

        [HttpPost()]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationRequest request, 
            CancellationToken cancellationToken)
        {
            var command = new RegistrationCommand(request.Email,
                request.Password,
                request.LastName,
                request.FirstName,
                request.Type);

            Result result=await Sender.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return HandleFailure(result);
        }

        [HttpGet()]
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
