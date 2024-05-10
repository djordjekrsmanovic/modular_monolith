using Booking.BuildingBlocks.Application.EventBus;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;
using Booking.UserAccess.IntegrationEvents.Commerce;

namespace Booking.Commerce.Application.Features.IntegrationEventHandlers
{
    public class PayerRegisteredIntegrationEventHandler : IntegrationEventHandler<PayerRegisteredIntegrationEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IPayerRepository _payerRepository;

        public PayerRegisteredIntegrationEventHandler(IUnitOfWork unitOfWork, IPayerRepository subscriberRepository)
        {
            _unitOfWork = unitOfWork;
            _payerRepository = subscriberRepository;
        }
        public override async Task Handle(PayerRegisteredIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Payer payer = Payer.Create(integrationEvnet.GustId);

            await _payerRepository.Add(payer);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
