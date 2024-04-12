using Booking.BuildingBlocks.Domain.Enums;
using Booking.BuildingBlocks.Domain.SharedKernel.ValueObjects;
using Booking.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Booking.Commerce.Infrastructure.Database.Configuration
{
    internal class ReservationInvoiceConfiguration : IEntityTypeConfiguration<ReservationInvoice>
    {
        public void Configure(EntityTypeBuilder<ReservationInvoice> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(reservation => reservation.BookingFee, bookingFee =>
            {
                // Assuming MoneyToKeepByPlatform is a property of type Money in BookingFee
                bookingFee.Property(x => x.MoneyToKeepByPlatfomr).HasConversion(
                    v => $"{v.Ammount},{v.Currency}",
                    v => Money.Create(ConvertStringToEnum(split(v, 1)), double.Parse(split(v, 0))).Value
                    );
            });



            builder.OwnsOne(x => x.Price);

            builder.HasOne(x => x.Payment);

            builder.HasIndex(x => x.ReservationId).IsUnique(true);
        }

        private string split(string v, int indexToReturn)
        {
            return v.Split(",")[indexToReturn];
        }

        private static Currency ConvertStringToEnum(string currency)
        {
            switch (currency)
            {
                case "USD": return Currency.USD;
                case "EUR": return Currency.EUR;
                case "RSD": return Currency.RSD;
                default: throw new InvalidOperationException();
            }
        }


    }


}
