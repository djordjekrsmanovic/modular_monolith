using Booking.BuildingBlocks.Application.Emails;
using Booking.UserAccess.Application.Abstractions;

namespace Booking.UserAccess.Infrastructure.Emails.RegistrationConfirmationEmail
{
    internal partial class UserAccessEmailSender : IUserAccessEmailSender
    {
        private IEmailSender _sender;

        public UserAccessEmailSender(IEmailSender sender)
        {
            _sender = sender;
        }

        public async Task SendRegistrationConfirmEmail(ConfirmRegistrationEmailRequest request)
        {
            RegistrationConfirmationTemplate template = new RegistrationConfirmationTemplate();
            template.WithSubstitution(RegistrationConfirmationTemplate.ConfirmationLink, $"http://localhost:4200/thank-you-registration?confirmation-code={request.ConfirmationCode}");
            _sender.SendEmailAsync(request.To, template.GenerateBody(), request.Subject);
        }
    }
}
