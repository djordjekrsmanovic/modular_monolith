using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Domain.Events;

namespace Booking.UserAccess.Application.Features.Registration.SubmitRegistrationRequest
{
    internal class RegistrationSubmittedDomainEventHandler : IDomainEventHandler<RegistrationRequestSubmittedDomainEvent>
    {
        private IUserAccessEmailSender _emailSender;

        private readonly string Subject = "Confirm your registration request";

        public RegistrationSubmittedDomainEventHandler(Abstractions.IUserAccessEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public async Task Handle(RegistrationRequestSubmittedDomainEvent notification, CancellationToken cancellationToken)
        {
            var request = new ConfirmRegistrationEmailRequest(notification.Email,Subject,notification.ConfirmationCode);
            _emailSender.SendRegistrationConfirmEmail(request);
        }
    }
}
