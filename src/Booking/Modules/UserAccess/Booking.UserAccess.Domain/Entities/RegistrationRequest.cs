﻿using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Domain.Enums;
using Booking.UserAccess.Domain.Errors;
using Booking.UserAccess.Domain.Events;
using Booking.UserAccess.Domain.ValueObjects;


namespace Booking.UserAccess.Domain.Entities
{
    public class RegistrationRequest : Entity<Guid>
    {
        public string Email { get; init; }

        public string Password { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string ConfirmationCode { get; private set; }

        public RegistrationStatus Status { get; private set; }

        public RegistrationType Type { get; private set; }

        public DateTime ConfirmationDate { get; private set; }

        public Result Confirm(string confirmationCode)
        {
            if (isRequestExpire()) 
            {
                Status=RegistrationStatus.Expired;
                return Result.Failure(RegistrationErrors.RegistrationRequestExpired);
            }
            
            return Status switch
            {
                var status when status == RegistrationStatus.Confirmed => Result.Failure(RegistrationErrors.RequestAlreadyConfirmed),
                var status when status == RegistrationStatus.Expired => Result.Failure(RegistrationErrors.RegistrationRequestExpired),
                _ => ConfirmInternal()
            };
        }

        private RegistrationRequest() { }


        private Result ConfirmInternal()
        {
            Status=RegistrationStatus.Confirmed;
            ConfirmationDate=DateTime.UtcNow;

            RaiseDomainEvent(new UserRegistrationConfirmedDomainEvent(Id));

            return Result.Success();
        }

        private bool isRequestExpire()
        {
            DateTime sevenDaysAgo=DateTime.UtcNow.AddDays(-7);
            return CreatedAt < sevenDaysAgo;
        }

        private RegistrationRequest(string email, string password, string firstName, string lastName,RegistrationType registrationType)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            CreatedAt = DateTime.UtcNow;
            ConfirmationCode = Guid.NewGuid().ToString();
            Status = RegistrationStatus.Waiting;
            Type = registrationType;
        }

        public static Result<RegistrationRequest> Create(string email,
            string firstName,
            string lastName, 
            string password,
            RegistrationType type)
        {
            RegistrationRequest request=new RegistrationRequest(email, firstName, lastName, password,type);

            request.RaiseDomainEvent(new RegistrationRequestSubmittedDomainEvent(email,request.ConfirmationCode));
            
            return Result.Success(request);
        }
    }
}
