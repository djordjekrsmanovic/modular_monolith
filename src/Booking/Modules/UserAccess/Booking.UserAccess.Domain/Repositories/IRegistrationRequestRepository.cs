using Booking.UserAccess.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Domain.Repositories
{
    public interface IRegistrationRequestRepository
    {
        Task Add(RegistrationRequest request);
        Task<RegistrationRequest> GetByConfirmationCodeAsync(string confirmationCode,CancellationToken token=default);
        Task<RegistrationRequest> GetByIdAsync(Guid Id);
    }
}
