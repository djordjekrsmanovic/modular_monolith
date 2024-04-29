using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class ReservationRequestRepository : IReservationRequestRepository
    {
        private readonly AccomodationDbContext _context;

        public ReservationRequestRepository(AccomodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ReservationRequest value)
        {
            _context.Set<ReservationRequest>().Add(value);
        }

        public async Task<ReservationRequest> GetAsync(Guid Id)
        {
            return await _context.Set<ReservationRequest>().Where(x => x.Id == Id).FirstOrDefaultAsync();
        }
    }
}
