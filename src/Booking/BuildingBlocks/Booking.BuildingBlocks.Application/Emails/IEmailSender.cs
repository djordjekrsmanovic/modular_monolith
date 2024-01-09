using System;


namespace Booking.BuildingBlocks.Application.Emails
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string body,string subject);
    }
}
