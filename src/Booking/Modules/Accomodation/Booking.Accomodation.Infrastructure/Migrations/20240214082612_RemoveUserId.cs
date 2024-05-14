using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.AccommodationNS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Host_UserId",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropIndex(
                name: "IX_Guest_UserId",
                schema: "accomodaton",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "accomodaton",
                table: "Guest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "accomodaton",
                table: "Host",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "accomodaton",
                table: "Guest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Host_UserId",
                schema: "accomodaton",
                table: "Host",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_UserId",
                schema: "accomodaton",
                table: "Guest",
                column: "UserId",
                unique: true);
        }
    }
}
