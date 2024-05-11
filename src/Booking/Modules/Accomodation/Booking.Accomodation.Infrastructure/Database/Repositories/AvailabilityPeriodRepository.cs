using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;

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
