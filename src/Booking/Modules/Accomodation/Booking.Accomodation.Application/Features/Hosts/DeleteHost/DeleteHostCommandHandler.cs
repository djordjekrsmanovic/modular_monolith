using Booking.AccommodationNS.Domain;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Domain.Errors;
using Booking.AccommodationNS.Domain.Repositories;
using Booking.Accomodation.Domain.Events;
using Booking.BuildingBlocks.Application.CQRS;
using Booking.BuildingBlocks.Domain;

namespace Booking.Accomodation.Application.Features.Hosts.DeleteHost
{
    internal class DeleteHostCommandHandler : ICommandHandler<DeleteHostCommand>
    {
        private readonly IHostRepository _hostRepository;

        private readonly IAccommodationRepository _accommodationRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DeleteHostCommandHandler(IHostRepository hostRepository, IAccommodationRepository accommodationRepository, IUnitOfWork unitOfWork)
        {
            _hostRepository = hostRepository;
            _accommodationRepository = accommodationRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteHostCommand request, CancellationToken cancellationToken)
        {
            List<Accommodation> accommodations = await _accommodationRepository.GetHostAccommodations(request.HostId);

            Host host = await _hostRepository.GetByIdAsync(request.HostId);

            bool hostCanBeDeleted = true;

            foreach (var accommodation in accommodations)
            {
                if (!accommodation.IsPosibleToDelete())
                {
                    hostCanBeDeleted = false;
                }
            }

            if (hostCanBeDeleted)
            {
                accommodations.ForEach(accommodation => { accommodation.Delete(); });
                host.RaiseDomainEvent(new HostDeletedDomainEvent(request.HostId));
                await _unitOfWork.SaveChangesAsync();
                return Result.Success();
            }

            return Result.Failure(HostErrors.UnableToDeleteHost);
        }
    }
}
