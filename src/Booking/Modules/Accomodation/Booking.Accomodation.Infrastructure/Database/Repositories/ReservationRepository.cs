﻿using Booking.Accomodation.Domain.Repositories;
using Booking.Booking.Domain.Entities;
using Booking.Booking.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Booking.Accomodation.Infrastructure.Database.Repositories
{
    internal class ReservationRepository : IReservationRepository
    {
        private readonly AccomodationDbContext _context;

        public ReservationRepository(AccomodationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Reservation value)
        {
            _context.Set<Reservation>().Add(value);
        }

        public async Task<List<Reservation>> GetGuestReservations(Guid guestId)
        {
            return await _context.Set<Reservation>().Where(x => x.GustId == guestId).ToListAsync();
        }
    }
}
