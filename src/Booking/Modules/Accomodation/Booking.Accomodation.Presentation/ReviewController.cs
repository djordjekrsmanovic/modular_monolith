using Booking.Accomodation.Application.Features.Reviews.AddReview;
using Booking.Accomodation.Application.Features.Reviews.GetAccommodationReviews;
using Booking.Accomodation.Presentation.Contracts;
using Booking.BuildingBlocks.Presentation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Accomodation.Presentation
{
    [Route("api/reviews")]
    public class ReviewController : ApiController
    {

        public ReviewController(ISender sender) : base(sender)
        {

        }

        [HttpGet("accommodation/{id}")]
        public async Task<IActionResult> GetAccommodationReviews(Guid id, CancellationToken cancellationToken)
        {

            var response = await Sender.Send(new GetAccommodationReviewsQuery(id), cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response.Value);

        }

        [HttpPost("")]
        public async Task<IActionResult> CreateReview([FromBody] CreateReviewRequest request, CancellationToken cancellationToken)
        {

            var response = await Sender.Send(new AddReviewCommand(request.ReservationId, request.GuestId, request.Comment, request.Rating), cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok();

        }
    }
}
