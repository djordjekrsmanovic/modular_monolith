

using Booking.BuildingBlocks.Application.Emails;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Booking.BuildingBlocks.Infrastructure
{
    public class EmailSender : IEmailSender
    {
        private const string From = "Booking Modular Monolith";
        private const string Adress = "bookingmodularmonolith@gmail.com";
        private const string SMTPHost = "smtp.gmail.com";
        private const int SMTPPort = 587;

        public async Task SendEmailAsync(string email, string body,string subject)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(From, Adress));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = subject;
            var bodyBuilder = new BodyBuilder { HtmlBody = body };
            message.Body = bodyBuilder.ToMessageBody();


            using (var client = new SmtpClient())
            {
                client.Connect(SMTPHost, SMTPPort, SecureSocketOptions.StartTls);
                client.Authenticate(Adress, "crat ryra wdfr vrmu");
                client.Send(message);
                client.Disconnect(true);
            }
        }


    }
}
