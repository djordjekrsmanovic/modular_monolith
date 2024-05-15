using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;

namespace Booking.AccommodationNS.Infrastructure.Database.Repositories
{
    internal class AvailabilityPeriodRepository : IAvailabilityPeriodRepository
    {
        private readonly AccommodationDbContext _context;

        public AvailabilityPeriodRepository(AccommodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(AvailabilityPeriod period)
        {
            _context.Add(period);
        }
    }
}
