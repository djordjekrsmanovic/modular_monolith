using Booking.BuildingBlocks.Infrastructure.Database;
using MediatR;

namespace Booking.UserAccess.Infrastructure.Database
{
    internal sealed class UnitOfWork : TUnitOfWork<UserAccessDbContext>
    {
        public UnitOfWork(UserAccessDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
