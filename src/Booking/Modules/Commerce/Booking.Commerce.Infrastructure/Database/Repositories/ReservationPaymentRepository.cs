using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Infrastructure.Database.Repositories
{
    internal class ReservationPaymentRepository : IReservationPaymentRepository
    {
        private CommerceDbContext _context;

        public ReservationPaymentRepository(CommerceDbContext context) { _context = context; }
        public async Task Add(ReservationPayment payment)
        {
            _context.Set<ReservationPayment>().Add(payment);
        }
    }
}
