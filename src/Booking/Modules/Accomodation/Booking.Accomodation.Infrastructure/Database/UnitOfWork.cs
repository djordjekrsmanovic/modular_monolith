using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Infrastructure.Database;
using Booking.BuildingBlocks.Infrastructure.Database;
using MediatR;

namespace Booking.AccommodationNS.Infrastructure.Database
{
    internal class UnitOfWork : TUnitOfWork<AccommodationDbContext>, IUnitOfWork
    {
        public UnitOfWork(AccommodationDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
