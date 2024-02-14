using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.UserAccess.IntegrationEvents.Accomodation;

namespace Booking.Booking.Application
{
    public class HostRegisteredIntegrationEventHandler : IntegrationEventHandler<HostRegisteredIntegrationEvent>
    {
        private readonly IHostRepository _hostRepository;
        private readonly IUnitOfWork _unitOfWork;

        public HostRegisteredIntegrationEventHandler(IHostRepository hostRepository, IUnitOfWork unitOfWork)
        {
            _hostRepository = hostRepository;
            _unitOfWork = unitOfWork;
        }

        public override async Task Handle(HostRegisteredIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Console.WriteLine("Example");
            Host host = Host.Create(integrationEvnet.HostId);

            _hostRepository.Add(host);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
