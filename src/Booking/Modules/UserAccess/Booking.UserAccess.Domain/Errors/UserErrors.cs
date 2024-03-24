using Booking.BuildingBlocks.Domain;
using Booking.BuildingBlocks.Domain.Enums;


namespace Booking.UserAccess.Domain.Errors
{
    public class UserErrors
    {
        public static readonly Error EmailNotUniqueError = new("User.EmailNotUnique", "Email must be unique!", ErrorType.ValidationError);

        public static readonly Error InvalidUserRole = new("User.InvalidRole", "User role is invalid!");

        public static readonly Error UserWithProvidedIdNotExist = new("User.InvalidUserId", "User not exist", ErrorType.BadRequest);

        public static readonly Error WrongPreviousPassword = new("User.WrongConfirmationPassword", "Password Confirmation Error", ErrorType.BadRequest);
    }
}
