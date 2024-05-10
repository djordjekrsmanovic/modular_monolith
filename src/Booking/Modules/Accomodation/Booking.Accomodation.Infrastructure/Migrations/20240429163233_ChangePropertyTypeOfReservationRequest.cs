using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Accomodation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePropertyTypeOfReservationRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTimeSlot_Start",
                schema: "accomodaton",
                table: "ReservationRequest",
                newName: "Slot_Start");

            migrationBuilder.RenameColumn(
                name: "DateTimeSlot_End",
                schema: "accomodaton",
                table: "ReservationRequest",
                newName: "Slot_End");

            migrationBuilder.RenameColumn(
                name: "Price_Currency",
                schema: "accomodaton",
                table: "Reservation",
                newName: "TotalPrice_Currency");

            migrationBuilder.RenameColumn(
                name: "Price_Ammount",
                schema: "accomodaton",
                table: "Reservation",
                newName: "TotalPrice_Ammount");

            migrationBuilder.RenameColumn(
                name: "DateTimeSlot_Start",
                schema: "accomodaton",
                table: "Reservation",
                newName: "Slot_Start");

            migrationBuilder.RenameColumn(
                name: "DateTimeSlot_End",
                schema: "accomodaton",
                table: "Reservation",
                newName: "Slot_End");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Slot_Start",
                schema: "accomodaton",
                table: "ReservationRequest",
                newName: "DateTimeSlot_Start");

            migrationBuilder.RenameColumn(
                name: "Slot_End",
                schema: "accomodaton",
                table: "ReservationRequest",
                newName: "DateTimeSlot_End");

            migrationBuilder.RenameColumn(
                name: "TotalPrice_Currency",
                schema: "accomodaton",
                table: "Reservation",
                newName: "Price_Currency");

            migrationBuilder.RenameColumn(
                name: "TotalPrice_Ammount",
                schema: "accomodaton",
                table: "Reservation",
                newName: "Price_Ammount");

            migrationBuilder.RenameColumn(
                name: "Slot_Start",
                schema: "accomodaton",
                table: "Reservation",
                newName: "DateTimeSlot_Start");

            migrationBuilder.RenameColumn(
                name: "Slot_End",
                schema: "accomodaton",
                table: "Reservation",
                newName: "DateTimeSlot_End");
        }
    }
}
