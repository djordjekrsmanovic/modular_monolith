using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class AdditionalServiceRepository : IAdditionalServiceRepository
    {
        private readonly AccomodationDbContext _context;

        public AdditionalServiceRepository(AccomodationDbContext context) { _context = context; }
        public async Task<List<AdditionalService>> GetAsync()
        {
            return _context.Set<AdditionalService>().ToList();
        }
    }
}
