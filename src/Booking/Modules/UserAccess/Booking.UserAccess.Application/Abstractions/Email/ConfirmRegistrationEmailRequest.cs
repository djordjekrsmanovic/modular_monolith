namespace Booking.UserAccess.Application.Abstractions.Email
{
    public record ConfirmRegistrationEmailRequest(string To, string Subject, string ConfirmationCode)
    {
    }
}