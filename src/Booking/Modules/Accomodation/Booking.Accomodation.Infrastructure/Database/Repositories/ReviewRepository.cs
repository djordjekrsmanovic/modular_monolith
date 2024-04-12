using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class ReviewRepository : IReviewRepository
    {
        private readonly AccomodationDbContext _accommodationDbContext;

        public ReviewRepository(AccomodationDbContext context)
        {
            _accommodationDbContext = context;
        }
        public async Task<List<Review>> GetAccommodationReviews(Guid accommodationId)
        {
            return _accommodationDbContext.Set<Review>().Where(review => review.AccomodationId == accommodationId).ToList();
        }
    }
}
