using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Booking.UserAccess.Infrastructure.Database.Repositories
{
    internal sealed class RegistrationRequestRepository : IRegistrationRequestRepository
    {
        private readonly UserAccessDbContext _context;
        public RegistrationRequestRepository(UserAccessDbContext userAccessDbContext)
        {
            _context = userAccessDbContext;
        }

        public async Task Add(RegistrationRequest request)
        {
            _context.Add(request);
        }

        public async Task<RegistrationRequest> GetByConfirmationCodeAsync(string confirmationCode, CancellationToken token = default)
        {
            return await _context.Set<RegistrationRequest>().Where(request=>request.ConfirmationCode==confirmationCode).FirstOrDefaultAsync();
        }

        public async Task<RegistrationRequest> GetByIdAsync(Guid Id)
        {
            return await _context.Set<RegistrationRequest>().Where(request=> request.Id==Id).FirstOrDefaultAsync();
        }

        
    }
}
