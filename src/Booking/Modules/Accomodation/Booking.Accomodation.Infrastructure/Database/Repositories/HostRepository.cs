using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class HostRepository : IHostRepository
    {

        private readonly AccomodationDbContext _context;

        public HostRepository(AccomodationDbContext context)
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
