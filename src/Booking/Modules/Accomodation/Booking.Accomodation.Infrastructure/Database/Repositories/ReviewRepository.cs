using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.AccommodationNS.Infrastructure.Database.Repositories
{
    internal class ReviewRepository : IReviewRepository
    {
        private readonly AccommodationDbContext _context;

        public ReviewRepository(AccommodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Review review)
        {
            _context.Add(review);
        }

        public async Task<List<Review>> GetAccommodationReviews(Guid accommodationId)
        {
            return _context.Set<Review>().Where(review => review.AccommodationId == accommodationId).ToList();
        }

        public async Task<Review> GetReservationReviewAsync(Guid reservationId)
        {
            return await _context.Set<Review>().Where(x => x.ReservationId == reservationId).FirstOrDefaultAsync();
        }
    }
}
