using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class PayerRepository : IPayerRepository
    {
        private CommerceDbContext _context;
        public async Task Add(Payer payer)
        {
            _context.Add(payer);
        }
    }
}
