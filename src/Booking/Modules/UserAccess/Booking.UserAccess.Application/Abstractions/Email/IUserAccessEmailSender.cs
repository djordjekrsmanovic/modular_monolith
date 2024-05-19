namespace Booking.UserAccess.Application.Abstractions.Email
{
    public interface IUserAccessEmailSender
    {
        Task SendRegistrationConfirmEmail(ConfirmRegistrationEmailRequest request);
    }
}
