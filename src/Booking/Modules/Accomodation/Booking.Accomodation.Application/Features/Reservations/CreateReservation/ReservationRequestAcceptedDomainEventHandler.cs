using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Events;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Application.Features.Reservations.CreateReservation
{
    public class ReservationRequestAcceptedDomainEventHandler : IDomainEventHandler<ReservationRequestAcceptedDomainEvent>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IReservationRepository _reservationRepository;

        public ReservationRequestAcceptedDomainEventHandler(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork, IReservationRepository reservationRepository)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(ReservationRequestAcceptedDomainEvent notification, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(notification.AccommodationId);

            var reservation = accommodation.AddReservation(notification.Slot, notification.GuestNumber, notification.GuestId, notification.ReservationRequestId);

            await _reservationRepository.Add(reservation.Value);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
