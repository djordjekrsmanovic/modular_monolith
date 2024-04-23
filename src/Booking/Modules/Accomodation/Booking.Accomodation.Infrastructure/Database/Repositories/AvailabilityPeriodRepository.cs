using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class AvailabilityPeriodRepository : IAvailabilityPeriodRepository
    {
        private readonly AccomodationDbContext _context;

        public AvailabilityPeriodRepository(AccomodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(AvailabilityPeriod period)
        {
            _context.Add(period);
        }
    }
}
