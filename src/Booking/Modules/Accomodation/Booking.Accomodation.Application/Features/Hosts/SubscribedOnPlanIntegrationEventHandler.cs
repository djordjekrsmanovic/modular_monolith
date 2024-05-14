﻿using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.Commerce.IntegrationEvents;

namespace Booking.AccommodationNS.Application.Features.Hosts
{
    public class SubscribedOnPlanIntegrationEventHandler : IntegrationEventHandler<SubscribedOnPlanIntegrationEvent>
    {

        private readonly IHostRepository _hostRepository;

        private readonly IUnitOfWork _unitOfWork;

        public SubscribedOnPlanIntegrationEventHandler(IHostRepository hostRepository, IUnitOfWork unitOfWork)
        {
            _hostRepository = hostRepository;
            _unitOfWork = unitOfWork;
        }

        public async override Task Handle(SubscribedOnPlanIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Host host = await _hostRepository.GetByIdAsync(integrationEvnet.SubscriberId);
            host.ExtendSubscription(integrationEvnet.SubscriptionExpirationDate, integrationEvnet.AccommodationLimit);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
