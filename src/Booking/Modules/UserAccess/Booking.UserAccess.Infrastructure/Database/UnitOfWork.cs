using Booking.BuildingBlocks.Infrastructure.Database;
using Booking.UserAccess.Domain;
using MediatR;

namespace Booking.UserAccess.Infrastructure.Database
{
    public sealed class UnitOfWork : TUnitOfWork<UserAccessDbContext>, IUnitOfWork
    {
        public UnitOfWork(UserAccessDbContext dbContext, IPublisher publisher) : base(dbContext, publisher)
        {
        }
    }
}
