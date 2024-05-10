using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface IReservationInvoiceRepository
    {
        Task Add(ReservationInvoice invoice);
    }
}
