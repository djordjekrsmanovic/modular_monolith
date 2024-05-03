﻿using Booking.Booking.Domain.Entities;

namespace Booking.Accomodation.Domain.Repositories
{
    public interface IReservationRepository
    {
        Task Add(Reservation reservation);

        public Task<List<Reservation>> GetGuestReservations(Guid guestId);
    }
}