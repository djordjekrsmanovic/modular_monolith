using Booking.UserAccess.Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Infrastructure.Emails.RegistrationConfirmationEmail
{
    internal partial class UserAccessEmailSender : IUserAccessEmailSender
    {
        

        public Task SendRegistrationExpiredEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
