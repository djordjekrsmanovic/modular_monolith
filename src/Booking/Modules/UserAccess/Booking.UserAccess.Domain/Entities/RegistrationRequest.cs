using Booking.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Domain.Entities
{
    public class RegistrationRequest : Entity<Guid>
    {
        public string Email { get; init; }

        public string Password { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }

        public DateTime CreatedAt { get; init; }

        public string VerificationCode { get; init; }

        public RegistrationStatus Status { get; init; }
    }
}
