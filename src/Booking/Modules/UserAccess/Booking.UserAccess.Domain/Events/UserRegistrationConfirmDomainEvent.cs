using Booking.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Domain.Events
{
    public sealed record UserRegistrationConfirmDomainEvent(Guid Id,
        DateTime OccurredOn,
        Guid UserRegistrationId) : DomainEvent(Id, OccurredOn)
    {

    }
    
}
