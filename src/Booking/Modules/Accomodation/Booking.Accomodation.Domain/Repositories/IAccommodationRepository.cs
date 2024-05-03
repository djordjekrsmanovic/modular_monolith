using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IAccommodationRepository
    {
        Task Add(Accommodation accommodation);

        Task<List<Accommodation>> Get(string? SearchTerm, string? SortColumn, string? SortOrder, int Page,
        int PageSize,
        DateTime StartDate,
        DateTime EndDate,
        string? Country);

        public Task<Accommodation> GetAsync(Guid Id);


        public Task<Accommodation> Get(Guid Id);

        public Task<Accommodation> GetFirstAccommodation(Guid hostId);

        public int GetNumberOfHostAccommodations(Guid hostId);

        void Update(Accommodation accommodation);
        Task<List<Accommodation>> GetHostAccommodations(Guid hostId);

        Accommodation GetWithoutRelations(Guid Id);
    }
}
