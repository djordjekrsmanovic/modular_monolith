using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class PayerRepository : IPayerRepository
    {
        private CommerceDbContext _context;

        public PayerRepository(CommerceDbContext context) { _context = context; }

        public async Task Add(Payer payer)
        {
            _context.Add(payer);
        }

        public async Task<Payer> GetAsync(Guid id)
        {
            return _context.Set<Payer>().Where(x => x.Id == id).Include(x => x.Invoices).ThenInclude(x => x.Payment).FirstOrDefault();
        }
    }
}
