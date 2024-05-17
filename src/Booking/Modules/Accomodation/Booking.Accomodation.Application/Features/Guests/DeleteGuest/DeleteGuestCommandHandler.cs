using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.Accomodation.Domain.Errors;
using Booking.Accomodation.Domain.Events;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Guests.DeleteGuest
{
    internal class DeleteGuestCommandHandler : ICommandHandler<DeleteGuestCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        private readonly IGuestRepository _guestRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DeleteGuestCommandHandler(IReservationRepository reservationRepository, IGuestRepository guestRepository, IUnitOfWork unitOfWork)
        {
            _reservationRepository = reservationRepository;
            _guestRepository = guestRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteGuestCommand request, CancellationToken cancellationToken)
        {
            Guest guest = await _guestRepository.GetAsync(request.GuestId);
            if (guest is null)
            {
                return Result.Failure(GuestErrors.GuestNotExist);
            }
            List<Reservation> reservations = await _reservationRepository.GetGuestReservations(request.GuestId);



            foreach (var reservation in reservations)
            {
                if (reservation.Slot.IsDateInSlot(DateTime.UtcNow) || reservation.Slot.IsDateBeforeSlot(DateTime.UtcNow))
                {
                    return Result.Failure(GuestErrors.FutureOrReservationInProgressExists);
                }
            }

            guest.RaiseDomainEvent(new GuestDeletedDomainEvent(request.GuestId));

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();


        }
    }
}
