using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.SharedKernel;
using Booking.BuildingBlocks.Presentation;
using Booking.UserAccess.Application.Features.Login;
using Booking.UserAccess.Application.Features.UserInfo.GetUserInfo;
using Booking.UserAccess.Application.Features.UserInfo.UpdateUserInfo;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserInfo(Guid Id, CancellationToken cancellationToken)
        {
            var query = new GetUserInfoQuery(Id);

            Result<UserInfoResponse> response = await Sender.Send(query, cancellationToken);
            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response.Value);
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateUserInfo([FromBody] UpdateUserInfoRequest request, CancellationToken cancellationToken)
        {

            UpdateUserInfoCommand command = new UpdateUserInfoCommand(request.Id, request.FirstName, request.LastName,
                request.Email, request.Phone, Address.Create(request.Street, request.City, request.Country),
                request.PreviousPassword, request.NewPassword);

            Result<Guid> response = await Sender.Send(command, cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response.Value);
        }
    }
}
