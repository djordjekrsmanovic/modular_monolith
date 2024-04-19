using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Accomodation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSubscriptionDetailsToHost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isBlocked",
                schema: "accomodaton",
                table: "Accommodation",
                newName: "IsBlocked");

            migrationBuilder.AddColumn<int>(
                name: "AccommodationLimit",
                schema: "accomodaton",
                table: "Host",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionExpirationDate",
                schema: "accomodaton",
                table: "Host",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "accomodaton",
                table: "Accommodation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccommodationLimit",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "SubscriptionExpirationDate",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "accomodaton",
                table: "Accommodation");

            migrationBuilder.RenameColumn(
                name: "IsBlocked",
                schema: "accomodaton",
                table: "Accommodation",
                newName: "isBlocked");
        }
    }
}
