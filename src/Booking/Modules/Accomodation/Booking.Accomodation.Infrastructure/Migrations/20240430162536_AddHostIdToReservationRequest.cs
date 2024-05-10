using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Accomodation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddHostIdToReservationRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HostId",
                schema: "accomodaton",
                table: "ReservationRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HostId",
                schema: "accomodaton",
                table: "ReservationRequest");
        }
    }
}
