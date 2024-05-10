using Booking.Accomodation.Domain.Events;
using Booking.BuildingBlocks.Domain;

namespace Booking.Booking.Domain.Entities
{
    public class Review : Entity<Guid>
    {
        public int Rating { get; private set; }

        public string Comment { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public Guid AccommodationId { get; private set; }

        public Guid GuestId { get; private set; }

        public Guid ReservationId { get; private set; }

        private Review() { }

        private Review(Guid reservationId, Guid guestId, Guid accommodationId, string comment, int rating)
        {
            Id = Guid.NewGuid();
            ReservationId = reservationId;
            GuestId = guestId;
            AccommodationId = accommodationId;
            CreatedAt = DateTime.UtcNow;
            Comment = comment;
            Rating = rating;
        }

        public static Result<Review> Create(Guid reservationId, Guid guestId, Guid accommodationId, string comment, int raiting)
        {
            var review = new Review(reservationId, guestId, accommodationId, comment, raiting);
            review.RaiseDomainEvent(new ReviewCreatedDomainEvent(accommodationId));
            return Result.Success(review);
        }
    }
}
