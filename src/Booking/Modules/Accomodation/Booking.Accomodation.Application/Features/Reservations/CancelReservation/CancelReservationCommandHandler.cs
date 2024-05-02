using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Reservations.CancelReservation
{
    public class CancelReservationCommandHandler : ICommandHandler<CancelReservationCommand>
    {

        public Task<Result> Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
