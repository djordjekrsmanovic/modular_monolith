using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Accomodation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveToComplexType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Price_Ammount",
                schema: "accomodaton",
                table: "Reservation",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                schema: "accomodaton",
                table: "Reservation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "NewPrice_Ammount",
                schema: "accomodaton",
                table: "PriceChangeTrack",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NewPrice_Currency",
                schema: "accomodaton",
                table: "PriceChangeTrack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "OldPrice_Ammount",
                schema: "accomodaton",
                table: "PriceChangeTrack",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OldPrice_Currency",
                schema: "accomodaton",
                table: "PriceChangeTrack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "NewPrice_Ammount",
                schema: "accomodaton",
                table: "AvailabilityPeriodChangeTrack",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NewPrice_Currency",
                schema: "accomodaton",
                table: "AvailabilityPeriodChangeTrack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "OldPrice_Ammount",
                schema: "accomodaton",
                table: "AvailabilityPeriodChangeTrack",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "OldPrice_Currency",
                schema: "accomodaton",
                table: "AvailabilityPeriodChangeTrack",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price_Ammount",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "PricePerGuest_Ammount",
                schema: "accomodaton",
                table: "Accommodation",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "PricePerGuest_Currency",
                schema: "accomodaton",
                table: "Accommodation",
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
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                schema: "accomodaton",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "NewPrice_Ammount",
                schema: "accomodaton",
                table: "PriceChangeTrack");

            migrationBuilder.DropColumn(
                name: "NewPrice_Currency",
                schema: "accomodaton",
                table: "PriceChangeTrack");

            migrationBuilder.DropColumn(
                name: "OldPrice_Ammount",
                schema: "accomodaton",
                table: "PriceChangeTrack");

            migrationBuilder.DropColumn(
                name: "OldPrice_Currency",
                schema: "accomodaton",
                table: "PriceChangeTrack");

            migrationBuilder.DropColumn(
                name: "NewPrice_Ammount",
                schema: "accomodaton",
                table: "AvailabilityPeriodChangeTrack");

            migrationBuilder.DropColumn(
                name: "NewPrice_Currency",
                schema: "accomodaton",
                table: "AvailabilityPeriodChangeTrack");

            migrationBuilder.DropColumn(
                name: "OldPrice_Ammount",
                schema: "accomodaton",
                table: "AvailabilityPeriodChangeTrack");

            migrationBuilder.DropColumn(
                name: "OldPrice_Currency",
                schema: "accomodaton",
                table: "AvailabilityPeriodChangeTrack");

            migrationBuilder.DropColumn(
                name: "Price_Ammount",
                schema: "accomodaton",
                table: "AvailabilityPeriod");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                schema: "accomodaton",
                table: "AvailabilityPeriod");

            migrationBuilder.DropColumn(
                name: "PricePerGuest_Ammount",
                schema: "accomodaton",
                table: "Accommodation");

            migrationBuilder.DropColumn(
                name: "PricePerGuest_Currency",
                schema: "accomodaton",
                table: "Accommodation");
        }
    }
}
