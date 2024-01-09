using Booking.BuildingBlocks.Application.Emails;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Application.Abstractions;
using Booking.UserAccess.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.UserAccess.Application.Features.Registration.SubmitRegistrationRequest
{
    internal class RegistrationSubmittedDomainEventHandler : IDomainEventHandler<RegistrationRequestSubmittedDomainEvent>
    {
        private Abstractions.IUserAccessEmailSender _emailSender;

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
