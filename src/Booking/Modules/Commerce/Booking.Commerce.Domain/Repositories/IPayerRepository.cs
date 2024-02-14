using Booking.Commerce.Domain.Entities;

namespace Booking.Commerce.Domain.Repositories
{
    public interface IPayerRepository
    {
        Task Add(Payer payer);
    }
}
