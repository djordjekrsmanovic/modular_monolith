using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.AccommodationNS.Infrastructure.Database.Repositories
{
    internal class ReservationRequestRepository : IReservationRequestRepository
    {
        private readonly AccommodationDbContext _context;

        public ReservationRequestRepository(AccommodationDbContext context)
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

        public async Task<List<ReservationRequest>> GetGuestReservationRequests(Guid guestId)
        {
            return await _context.Set<ReservationRequest>().Where(x => x.GuestId == guestId).ToListAsync();
        }

        public async Task<List<ReservationRequest>> GetHostReservationRequests(Guid hostId)
        {
            return await _context.Set<ReservationRequest>().Where(x => x.HostId == hostId).OrderBy(x => x.Slot.Start).ToListAsync();
        }
    }
}
