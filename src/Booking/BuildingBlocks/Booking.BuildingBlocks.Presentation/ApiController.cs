using Booking.BuildingBlocks.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Booking.BuildingBlocks.Presentation
{
    [ApiController]
    public abstract class ApiController : ControllerBase
    {

        protected readonly ISender Sender;

        protected ApiController(ISender sender)
        {
            Sender = sender;
        }

        protected IActionResult HandleFailure(Result result) =>
        result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException(),

            _ =>
                BadRequest(new ProblemDetails
                {
                    Title = "Bad Request",
                    Type = result.Error.Code,
                    Detail = result.Error.Description,
                    Status = StatusCodes.Status400BadRequest
                })
        };


    }
}
