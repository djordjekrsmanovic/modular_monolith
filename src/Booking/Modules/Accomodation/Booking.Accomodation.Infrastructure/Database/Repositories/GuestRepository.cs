using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class GuestRepository : IGuestRepository
    {
        private readonly AccomodationDbContext _context;

        public GuestRepository(AccomodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Guest guest)
        {
            _context.Add(guest);
        }
    }
}
