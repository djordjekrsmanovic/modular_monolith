using Booking.AccommodationNS.Domain.Repositories;
using Booking.AccommodationNS.Domain.Entities;
using Booking.AccommodationNS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Booking.AccommodationNS.Infrastructure.Database.Repositories
{
    internal class AccommodationRepository : IAccommodationRepository
    {
        private readonly AccommodationDbContext _context;

        public AccommodationRepository(AccommodationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Accommodation accommodation)
        {
            _context.Add(accommodation);
        }

        public async Task<List<Accommodation>> Get(string? SearchTerm, string? SortColumn, string? SortOrder, int Page,
        int PageSize, DateTime StartDate, DateTime EndDate, string? Country)
        {
            IQueryable<Accommodation> accommodationsQuery = _context.Set<Accommodation>();



            accommodationsQuery = accommodationsQuery.Where(accommodation => accommodation.Address.Country == Country);

            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                accommodationsQuery = accommodationsQuery.Where(accommodation =>
                    accommodation.Name.Contains(SearchTerm)
                    || (accommodation.Address.City).Contains(SearchTerm));
            }

            if (SortOrder is not null)
            {
                if (SortOrder.ToLower() == "desc")
                {
                    accommodationsQuery = accommodationsQuery.OrderByDescending(GetSortProperty(SortColumn));
                }
                else
                {
                    accommodationsQuery = accommodationsQuery.OrderBy(GetSortProperty(SortColumn));
                }
            }

            var accommodations = await accommodationsQuery.Include(accommodation => accommodation.AvailabilityPeriods)
                .Include(accommodation => accommodation.Reservations)
                .Include(accomodation => accomodation.AdditionalServices)
                .Include(accommodation => accommodation.Images).ToListAsync();

            return accommodations;
        }

        private static Expression<Func<Accommodation, object>> GetSortProperty(string sortColumn) =>
        sortColumn.ToLower() switch
        {
            "name" => accommodation => accommodation.Name,
            "price" => accommodation => accommodation.PricePerGuest.Ammount,
            "raiting" => accommodation => accommodation.Raiting,
            _ => accommodation => accommodation.Id
        };

        public async Task<Accommodation> GetAsync(Guid Id)
        {

            return await _context.Set<Accommodation>().Where(accommodation => accommodation.Id == Id)
                .Include(x => x.AvailabilityPeriods).Include(x => x.Reservations)
                .Include(x => x.AdditionalServices)
                .Include(x => x.Images).FirstOrDefaultAsync();
        }

        public Accommodation GetWithoutRelations(Guid Id)
        {

            return _context.Set<Accommodation>().Where(accommodation => accommodation.Id == Id).FirstOrDefault();
        }

        public async Task<Accommodation> GetFirstAccommodation(Guid hostId)
        {
            return await _context.Set<Accommodation>().OrderBy(x => x.CreatedAt).FirstAsync();
        }

        public int GetNumberOfHostAccommodations(Guid hostId)
        {
            return _context.Set<Accommodation>().Where(x => x.HostId == hostId).ToList().Count();
        }

        public void Update(Accommodation accommodation)
        {
            _context.Set<Accommodation>().Update(accommodation);
        }

        public async Task<Accommodation> Get(Guid Id)
        {
            return _context.Set<Accommodation>().Where(x => x.Id == Id).FirstOrDefault();
        }

        public async Task<List<Accommodation>> GetHostAccommodations(Guid hostId)
        {
            return await _context.Set<Accommodation>().Where(accommodation => accommodation.HostId == hostId)
                .Include(x => x.AdditionalServices)
                .Include(x => x.Reservations)
                .Include(x => x.Images).ToListAsync();
        }
    }
}
