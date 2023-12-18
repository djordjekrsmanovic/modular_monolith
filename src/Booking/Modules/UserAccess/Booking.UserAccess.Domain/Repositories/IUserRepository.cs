using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Booking.UserAccess.Domain.Entities;

namespace Booking.UserAccess.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmailAsync(string username, CancellationToken cancellationToken = default);
    }
}
