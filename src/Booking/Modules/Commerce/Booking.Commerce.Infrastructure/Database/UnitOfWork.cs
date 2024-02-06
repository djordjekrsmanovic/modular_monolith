using Booking.BuildingBlocks.Infrastructure.Database;
using MediatR;

namespace Booking.Commerce.Infrastructure.Database
{
    internal class UnitOfWork : TUnitOfWork<CommerceDbContext>
    {
        public UnitOfWork(CommerceDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
