using Booking.BuildingBlocks.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Domain.Errors
{
    public class RegistrationErrors
    {
        public static readonly Error InvalidConfirmationCode = new("Registration.ConfirmationCodeNotValid", "Confirmation code is not valid!");

        public static Error RegistrationRequestExpired = new("Registration.RequestExpired", "Registration request is expired!");

        public static Error RequestAlreadyConfirmed = new("Registration.RequestAlreadyConfirmed", "Registration request is already confirmed");
    }
}
