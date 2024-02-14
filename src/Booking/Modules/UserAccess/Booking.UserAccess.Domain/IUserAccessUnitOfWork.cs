namespace Booking.UserAccess.Domain
{
    public interface IUserAccessUnitOfWork
    {
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
