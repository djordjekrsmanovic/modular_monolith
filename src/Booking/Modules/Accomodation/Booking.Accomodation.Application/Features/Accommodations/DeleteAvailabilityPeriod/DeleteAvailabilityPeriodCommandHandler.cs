using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Errors;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.AccommodationNS.Application.Features.Accommodations.DeleteAvailabilityPeriod
{
    internal class DeleteAvailabilityPeriodCommandHandler : ICommandHandler<DeleteAvailabilityPeriodCommand>
    {
        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;


        public DeleteAvailabilityPeriodCommandHandler(IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork)
        {
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteAvailabilityPeriodCommand request, CancellationToken cancellationToken)
        {
            Accommodation accommodation = await _accommodationRepository.GetAsync(request.AccommodationId);

            if (accommodation is null)
            {
                return Result.Failure(AccommodationErrors.IdNotExist);
            }

            var result = accommodation.RemoveAvailabilityPeriod(request.AvailabilityPeriodId);

            if (result.IsSuccess)
            {
                _unitOfWork.SaveChangesAsync();
            }

            return result;
        }
    }
}
