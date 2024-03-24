using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Presentation;
using Booking.UserAccess.Application.Features.Login;
using Booking.UserAccess.Presentation.Contracts.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.UserAccess.Presentation
{
    [Route("api/users")]
    public class UserController : ApiController
    {

        public UserController(ISender sender) : base(sender)
        {

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.email, request.password);
            Result<LoginResponse> loginResponse = await Sender.Send(command, cancellationToken);

            if (loginResponse.IsFailure)
            {
                return HandleFailure(loginResponse);
            }

            return Ok(loginResponse.Value);
        }
    }
}
