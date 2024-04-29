using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IReservationRequestRepository
    {
        Task Add(ReservationRequest value);

        Task<ReservationRequest> GetAsync(Guid Id);
    }
}
