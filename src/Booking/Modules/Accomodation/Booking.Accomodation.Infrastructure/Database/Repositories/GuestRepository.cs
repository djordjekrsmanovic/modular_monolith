using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.AccommodationNS.Infrastructure.Database.Repositories
{
    internal class GuestRepository : IGuestRepository
    {
        private readonly AccommodationDbContext _context;

        public GuestRepository(AccommodationDbContext context)
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
