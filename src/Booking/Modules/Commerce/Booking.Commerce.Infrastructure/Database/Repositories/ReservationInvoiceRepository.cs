using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class ReservationInvoiceRepository : IReservationInvoiceRepository
    {
        private readonly CommerceDbContext _context;

        public ReservationInvoiceRepository(CommerceDbContext context)
        {
            _context = context;
        }

        public async Task Add(ReservationInvoice invoice)
        {
            _context.Set<ReservationInvoice>().Add(invoice);
        }
    }
}
