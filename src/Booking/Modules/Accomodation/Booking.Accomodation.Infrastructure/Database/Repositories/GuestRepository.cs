using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Guest> GetAsync(Guid guestId)
        {
            return await _context.Set<Guest>().Where(x => x.Id == guestId).FirstOrDefaultAsync();
        }
    }
}
