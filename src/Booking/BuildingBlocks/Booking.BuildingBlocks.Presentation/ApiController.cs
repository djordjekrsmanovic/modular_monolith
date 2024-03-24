using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;
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

            { Error: { ErrorType: ErrorType.BadRequest } } =>
                BadRequest(new ProblemDetails
                {
                    Title = "Bad Request",
                    Type = result.Error.Code,
                    Detail = result.Error.Description,
                    Status = StatusCodes.Status400BadRequest
                }),
            { Error: { ErrorType: ErrorType.Unauthorized } } =>
                StatusCode(StatusCodes.Status401Unauthorized, new ProblemDetails
                {
                    Title = "Unauthorized",
                    Type = result.Error.Code,
                    Detail = result.Error.Description,
                    Status = StatusCodes.Status401Unauthorized
                }),
            { Error: { ErrorType: ErrorType.ValidationError } } =>
                StatusCode(StatusCodes.Status409Conflict, new ProblemDetails
                {
                    Title = "ValidationError",
                    Type = result.Error.Code,
                    Detail = result.Error.Description,
                    Status = StatusCodes.Status409Conflict
                }),
            _ => throw new ArgumentException("Unknown error type")

        };


    }
}
