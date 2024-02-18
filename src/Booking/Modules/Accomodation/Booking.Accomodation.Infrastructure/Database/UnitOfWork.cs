using Booking.Accomodation.Domain;
using Booking.Booking.Infrastructure.Database;
using Booking.BuildingBlocks.Infrastructure.Database;
using MediatR;

namespace Booking.Accomodation.Infrastructure.Database
{
    internal class UnitOfWork : TUnitOfWork<AccomodationDbContext>, IUnitOfWork
    {
        public UnitOfWork(AccomodationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
