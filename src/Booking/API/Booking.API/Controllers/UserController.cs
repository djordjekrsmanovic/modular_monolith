using Booking.API.Abstractions;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Application;
using Booking.UserAccess.Application.Features.Login;
using Booking.UserAccess.Domain.Enums;
using Booking.UserAccess.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [Route("api/users")]
    public class UserController:ApiController
    {

        public UserController(ISender sender):base(sender)
        {

        }

        [HasPermissionAtribute(Permission.ReadMember)]
        [HttpGet("")]
        public async Task<IActionResult> GetUserById(
        CancellationToken cancellationToken)
        {

           var command=new GetUserCommand(Guid.NewGuid());

           Result<Guid> result=await Sender.Send(command, cancellationToken);

            return CreatedAtAction(
            nameof(GetUserById),
            new { id = result.Value});

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request,CancellationToken cancellationToken)
        {
            var command = new LoginCommand(request.email, request.password);
            Result<string> tokenResult=await Sender.Send(command,cancellationToken);

            if (tokenResult.IsFailure)
            {
                return HandleFailure(tokenResult);
            }

            return Ok(tokenResult.Value);
        }
    }
}
