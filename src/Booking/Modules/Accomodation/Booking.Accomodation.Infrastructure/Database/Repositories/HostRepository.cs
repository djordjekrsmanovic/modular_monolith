using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;

namespace Booking.AccommodationNS.Infrastructure.Database.Repositories
{
    internal class HostRepository : IHostRepository
    {

        private readonly AccommodationDbContext _context;

        public HostRepository(AccommodationDbContext context)
        {
            _context = context;
        }

        public void Add(Host host)
        {
            _context.Add(host);
        }

        public async Task<Host> GetByIdAsync(Guid id)
        {
            return _context.Set<Host>().Where(h => h.Id == id).FirstOrDefault();
        }
    }
}
