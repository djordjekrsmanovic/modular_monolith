using Booking.UserAccess.Domain.Entities;

namespace Booking.UserAccess.Domain.Repositories
{
    public interface IRegistrationRequestRepository
    {
        Task Add(RegistrationRequest request);
        Task<RegistrationRequest> GetByConfirmationCodeAsync(string confirmationCode,CancellationToken token=default);
        Task<RegistrationRequest> GetByIdAsync(Guid Id);
    }
}
