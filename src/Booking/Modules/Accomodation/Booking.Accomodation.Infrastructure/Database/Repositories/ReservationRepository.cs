using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.AccommodationNS.Infrastructure.Database.Repositories
{
    internal class ReservationRepository : IReservationRepository
    {
        private readonly AccommodationDbContext _context;

        public ReservationRepository(AccommodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Reservation value)
        {
            _context.Set<Reservation>().Add(value);
        }

        public async Task<Reservation> GetAsync(Guid reservationId)
        {
            return await _context.Set<Reservation>().Where(x => x.Id == reservationId).FirstOrDefaultAsync();
        }

        public async Task<List<Reservation>> GetGuestReservations(Guid guestId)
        {
            return await _context.Set<Reservation>().Where(x => x.GustId == guestId).ToListAsync();
        }
    }
}
