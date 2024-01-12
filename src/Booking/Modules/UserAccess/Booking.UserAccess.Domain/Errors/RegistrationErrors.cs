using Booking.BuildingBlocks.Domain;

namespace Booking.UserAccess.Domain.Errors
{
    public class RegistrationErrors
    {
        public static readonly Error InvalidConfirmationCode = new("Registration.ConfirmationCodeNotValid", "Confirmation code is not valid!");

        public static readonly Error RegistrationRequestExpired = new("Registration.RequestExpired", "Registration request is expired!");

        public static readonly Error RequestAlreadyConfirmed = new("Registration.RequestAlreadyConfirmed", "Registration request is already confirmed");
    }
}
