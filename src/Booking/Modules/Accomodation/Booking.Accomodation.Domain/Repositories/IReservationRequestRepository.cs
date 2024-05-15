using Booking.AccommodationNS.Domain.Entities;

namespace Booking.AccommodationNS.Domain.Repositories
{
    public interface IReservationRequestRepository
    {
        Task Add(ReservationRequest value);

        Task<ReservationRequest> GetAsync(Guid Id);

        Task<List<ReservationRequest>> GetHostReservationRequests(Guid hostId);

        Task<List<ReservationRequest>> GetGuestReservationRequests(Guid guestId);
    }
}
