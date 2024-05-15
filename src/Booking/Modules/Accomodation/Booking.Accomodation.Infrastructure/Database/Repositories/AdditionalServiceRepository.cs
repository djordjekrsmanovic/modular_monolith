using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;

namespace Booking.AccommodationNS.Infrastructure.Database.Repositories
{
    internal class AdditionalServiceRepository : IAdditionalServiceRepository
    {
        private readonly AccommodationDbContext _context;

        public AdditionalServiceRepository(AccommodationDbContext context) { _context = context; }
        public async Task<List<AdditionalService>> GetAsync()
        {
            return _context.Set<AdditionalService>().ToList();
        }
    }
}
