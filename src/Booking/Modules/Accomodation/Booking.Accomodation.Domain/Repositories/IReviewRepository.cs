using Booking.AccommodationNS.Domain.Entities;

namespace Booking.AccommodationNS.Domain.Repositories
{
    public interface IReviewRepository
    {
        Task<List<Review>> GetAccommodationReviews(Guid accommodationId);

        Task Add(Review review);

        Task<Review> GetReservationReviewAsync(Guid reservationId);
    }
}
