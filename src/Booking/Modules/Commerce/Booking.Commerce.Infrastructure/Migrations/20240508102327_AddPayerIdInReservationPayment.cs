using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPayerIdInReservationPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PayerId",
                schema: "commerce",
                table: "ReservationPayment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayerId",
                schema: "commerce",
                table: "ReservationPayment");
        }
    }
}
