using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface IReservationPaymentRepository
    {
        Task Add(ReservationPayment payment);
    }
}
