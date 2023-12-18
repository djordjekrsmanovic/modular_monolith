using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Presentation.Contracts
{
    public record LoginRequest(string email, string password)
    {
    }
}
