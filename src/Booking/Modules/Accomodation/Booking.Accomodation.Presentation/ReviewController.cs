using Booking.Accomodation.Application.Features.Reviews.GetAccommodationReviews;
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

        [HttpGet("accommodation/{accommodationId}")]
        public async Task<IActionResult> GetAdditionalServices(Guid Id, CancellationToken cancellationToken)
        {

            var response = await Sender.Send(new GetAccommodationReviewsQuery(Id), cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }
            return Ok(response.Value);

        }
    }
}
