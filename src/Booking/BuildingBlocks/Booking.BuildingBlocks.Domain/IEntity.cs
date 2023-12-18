using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.BuildingBlocks.Domain
{
    public interface IEntity
    {
        void Raise(IDomainEvent domainEvent);

        void ClearDomainEvents();

        IReadOnlyCollection<IDomainEvent> GetDomainEvents();
    }
}
