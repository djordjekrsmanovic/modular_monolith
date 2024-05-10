using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class ReservationRepository : IReservationRepository
    {
        private readonly DbSet<Reservation> _reservations;

        public ReservationRepository(CommerceDbContext context)
        {
            _reservations = context.Set<Reservation>();
        }

        public async Task Add(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        public async Task<Reservation> Get(Guid id)
        {
            return await _reservations.Where(x => x.Id == id).Include(x => x.Payments).FirstOrDefaultAsync();
        }
    }
}
