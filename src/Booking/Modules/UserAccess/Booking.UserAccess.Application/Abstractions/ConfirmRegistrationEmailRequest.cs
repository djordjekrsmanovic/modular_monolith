namespace Booking.UserAccess.Application.Abstractions
{
    public record ConfirmRegistrationEmailRequest(string To,string Subject,string ConfirmationCode)
    {
    }
}