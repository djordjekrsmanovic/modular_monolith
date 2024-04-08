using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAccommodationReviews(Guid accommodationId);
    }
}
