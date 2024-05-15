
using Booking.AccommodationNS.IntegrationEvents;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain;
using Booking.Commerce.Domain.Entities;
using Booking.Commerce.Domain.Repositories;

namespace Booking.Commerce.Application.Features.IntegrationEventHandlers
{
    public class ReservationCreatedIntegrationEventHandler : IntegrationEventHandler<ReservationCreatedIntegrationEvent>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ReservationCreatedIntegrationEventHandler(IReservationRepository reservationRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _unitOfWork = unitOfWork;
        }

        public async override Task Handle(ReservationCreatedIntegrationEvent integrationEvnet, CancellationToken token = default)
        {
            Reservation reservation = Reservation.Create(integrationEvnet.ReservationId, Money.Create(integrationEvnet.Currency, integrationEvnet.Amount).Value).Value;

            await _reservationRepository.Add(reservation);

            await _unitOfWork.SaveChangesAsync();

        }
    }
}
