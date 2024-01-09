

namespace Booking.UserAccess.Application.Abstractions
{
    public interface IUserAccessEmailSender
    {
        Task SendRegistrationConfirmEmail(ConfirmRegistrationEmailRequest request);
        Task SendRegistrationExpiredEmail(string email);
    }
}
