using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class HostRepository : IHostRepository
    {

        private AccomodationDbContext _context;

        public HostRepository(AccomodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Host host)
        {
            _context.Add(host);
        }
    }
}
