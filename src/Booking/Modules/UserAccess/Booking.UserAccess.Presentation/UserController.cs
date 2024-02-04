using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Presentation;
using Booking.UserAccess.Application.Features.Login;
using Booking.UserAccess.Presentation.Contracts;
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
            Result<string> tokenResult = await Sender.Send(command, cancellationToken);

            if (tokenResult.IsFailure)
            {
                return HandleFailure(tokenResult);
            }

            return Ok(tokenResult.Value);
        }
    }
}
