using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.AccommodationNS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "accomodaton",
                table: "Host",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Host_UserId",
                schema: "accomodaton",
                table: "Host",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Host_UserId",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "accomodaton",
                table: "Host");
        }
    }
}
