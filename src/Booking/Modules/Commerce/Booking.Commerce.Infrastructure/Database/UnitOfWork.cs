using Booking.BuildingBlocks.Infrastructure.Database;
using Booking.Commerce.Domain;
using MediatR;

namespace Booking.Commerce.Infrastructure.Database
{
    internal class UnitOfWork : TUnitOfWork<CommerceDbContext>, IUnitOfWork
    {
        public UnitOfWork(CommerceDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
