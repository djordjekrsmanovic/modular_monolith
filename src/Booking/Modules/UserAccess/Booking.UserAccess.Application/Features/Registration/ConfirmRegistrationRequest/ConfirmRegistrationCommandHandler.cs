﻿using Booking.BuildingBlocks.Application;
using Booking.BuildingBlocks.Domain;
using Booking.UserAccess.Domain;
using Booking.UserAccess.Domain.Entities;
using Booking.UserAccess.Domain.Errors;
using Booking.UserAccess.Domain.Repositories;

namespace Booking.UserAccess.Application.Features.Registration.ConfirmRegistrationRequest
{
    internal class ConfirmRegistrationCommandHandler : ICommandHandler<ConfirmRegistrationCommand>
    {
        private IRegistrationRequestRepository _registrationRequestRepository;
        private IUserRepository _userRepository;
        private IUnitOfWork _unitOfWork;

        public ConfirmRegistrationCommandHandler(IRegistrationRequestRepository registrationRequestRepository , 
            IUserRepository userRepository,
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _registrationRequestRepository = registrationRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(ConfirmRegistrationCommand request, CancellationToken cancellationToken)
        {
            RegistrationRequest registrationRequest = _registrationRequestRepository.GetByConfirmationCodeAsync(request.ConfirmationCode).Result;
            
            if (registrationRequest is  null) 
            {
                return Result.Failure(RegistrationErrors.InvalidConfirmationCode);
            }

            if (!_userRepository.IsEmailUniqueAsync(registrationRequest.Email).Result)
            {
                return Result.Failure(UserErrors.EmailNotUniqueError);
            }

            Result result=registrationRequest.Confirm(request.ConfirmationCode);

            await _unitOfWork.SaveChangesAsync();

            return result;
        }
    }
}