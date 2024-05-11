using Booking.Accomodation.Domain;
using Booking.Accomodation.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.UserAccess.IntegrationEvents.Accomodation;

namespace Booking.Accomodation.Application.Features.Guests
{
    public class GuestRegisteredIntegrationEventHandler : IntegrationEventHandler<GuestRegisteredIntegrationEvent>
    {
        private readonly IGuestRepository _guestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public GuestRegisteredIntegrationEventHandler(IGuestRepository guestRepository, IUnitOfWork unitOfWork)
        {
            _guestRepository = guestRepository;
            _unitOfWork = unitOfWork;
        }
        public override async Task Handle(GuestRegisteredIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Guest guest = Guest.Create(integrationEvnet.GustId);

            await _guestRepository.Add(guest);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
