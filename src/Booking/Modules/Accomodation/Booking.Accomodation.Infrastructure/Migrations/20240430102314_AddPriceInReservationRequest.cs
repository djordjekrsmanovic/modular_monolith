using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Accomodation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceInReservationRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price_Ammount",
                schema: "accomodaton",
                table: "ReservationRequest",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                schema: "accomodaton",
                table: "ReservationRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price_Ammount",
                schema: "accomodaton",
                table: "ReservationRequest");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                schema: "accomodaton",
                table: "ReservationRequest");
        }
    }
}
