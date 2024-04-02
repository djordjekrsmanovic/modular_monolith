using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class AccommodationRepository : IAccommodationRepository
    {
        private readonly AccomodationDbContext _context;

        public AccommodationRepository(AccomodationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Accommodation accommodation)
        {
            _context.Add(accommodation);
        }
    }
}
