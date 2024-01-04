using Booking.BuildingBlocks.Domain;


namespace Booking.UserAccess.Domain.Errors
{
    public class UserErrors
    {
        public static readonly Error EmailNotUniqueError = new("User.EmailNotUnique", "Email must be unique!");

        public static Error InvalidUserRole { get; internal set; }
    }
}
