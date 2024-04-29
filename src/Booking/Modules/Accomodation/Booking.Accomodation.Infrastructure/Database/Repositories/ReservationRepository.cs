using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class ReservationRepository : IReservationRepository
    {
        private readonly AccomodationDbContext _context;

        public ReservationRepository(AccomodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Reservation value)
        {
            _context.Set<Reservation>().Add(value);
        }

    }
}
