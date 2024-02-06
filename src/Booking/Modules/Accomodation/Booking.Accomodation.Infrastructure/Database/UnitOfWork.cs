using Booking.Booking.Infrastructure.Database;
using Booking.BuildingBlocks.Infrastructure.Database;
using MediatR;

namespace Booking.Accomodation.Infrastructure.Database
{
    internal class UnitOfWork : TUnitOfWork<AccomodationDbContext>
    {
        public UnitOfWork(AccomodationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
