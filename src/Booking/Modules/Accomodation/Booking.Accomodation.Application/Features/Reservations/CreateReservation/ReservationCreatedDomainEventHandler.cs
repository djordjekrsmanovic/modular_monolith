using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Domain.Enums;
using Booking.AccommodationNS.Domain.Events;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.IntegrationEvents;
using Booking.BuildingBlocks.Application.EventBus;
using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Application.Features.Reservations.CreateReservation
{
    internal class ReservationCreatedDomainEventHandler : IDomainEventHandler<ReservationCreatedDomainEvent>
    {

        private readonly IEventBus _eventBus;

        private readonly IReservationRequestRepository _reservationRequestRepository;

        private readonly IUnitOfWork _unitOfWork;

        public ReservationCreatedDomainEventHandler(IEventBus eventBus, IReservationRequestRepository reservationRequestRepository, IUnitOfWork unitOfWork)
        {
            _eventBus = eventBus;
            _reservationRequestRepository = reservationRequestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ReservationCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

            List<ReservationRequest> reservationRequests = await _reservationRequestRepository.GetAccommodationRequests(notification.AccommodationId);

            reservationRequests.ForEach(x =>
            {
                if (x.Slot.IsSlotOverlaping(notification.ReservationTimeSlot) && x.Status == ReservationRequestStatus.Waiting)
                {
                    x.Cancel();
                }
            });

            await _unitOfWork.SaveChangesAsync();

            await _eventBus.PublishAsync(new ReservationCreatedIntegrationEvent(notification.ReservationId, notification.Price.Ammount, notification.Price.Currency));
        }
    }
}
