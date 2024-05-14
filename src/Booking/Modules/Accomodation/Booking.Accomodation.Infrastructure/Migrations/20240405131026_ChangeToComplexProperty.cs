using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.AccommodationNS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToComplexProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailabilityPeriod_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod");

            migrationBuilder.RenameColumn(
                name: "DateTimeSlot_Start",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                newName: "Slot_Start");

            migrationBuilder.RenameColumn(
                name: "DateTimeSlot_End",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                newName: "Slot_End");

            migrationBuilder.RenameColumn(
                name: "AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                newName: "AccommodationId");

            migrationBuilder.RenameIndex(
                name: "IX_AvailabilityPeriod_AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                newName: "IX_AvailabilityPeriod_AccommodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailabilityPeriod_Accommodation_AccommodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                column: "AccommodationId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailabilityPeriod_Accommodation_AccommodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod");

            migrationBuilder.RenameColumn(
                name: "Slot_Start",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                newName: "DateTimeSlot_Start");

            migrationBuilder.RenameColumn(
                name: "Slot_End",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                newName: "DateTimeSlot_End");

            migrationBuilder.RenameColumn(
                name: "AccommodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                newName: "AccomodationId");

            migrationBuilder.RenameIndex(
                name: "IX_AvailabilityPeriod_AccommodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                newName: "IX_AvailabilityPeriod_AccomodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailabilityPeriod_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
