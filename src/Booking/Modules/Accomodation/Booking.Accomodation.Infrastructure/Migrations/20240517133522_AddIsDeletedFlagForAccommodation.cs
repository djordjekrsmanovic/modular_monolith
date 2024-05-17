using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.AccommodationNS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsDeletedFlagForAccommodation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailabilityPeriodChangeTrack",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "GuestFavouriteAccomodation",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "GuestVisitedAccomodation",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "PriceChangeTrack",
                schema: "accomodaton");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "accomodaton",
                table: "Accommodation",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "accomodaton",
                table: "Accommodation");

            migrationBuilder.CreateTable(
                name: "AvailabilityPeriodChangeTrack",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailabilityPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NewPrice_Ammount = table.Column<double>(type: "float", nullable: false),
                    NewPrice_Currency = table.Column<int>(type: "int", nullable: false),
                    NewTimeSlot_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewTimeSlot_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldPrice_Ammount = table.Column<double>(type: "float", nullable: false),
                    OldPrice_Currency = table.Column<int>(type: "int", nullable: false),
                    OldTimeSlot_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldTimeSlot_Start = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityPeriodChangeTrack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GuestFavouriteAccomodation",
                schema: "accomodaton",
                columns: table => new
                {
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FavouriteAccomodationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestFavouriteAccomodation", x => new { x.AccomodationId, x.GuestId });
                    table.ForeignKey(
                        name: "FK_GuestFavouriteAccomodation_Accommodation_FavouriteAccomodationsId",
                        column: x => x.FavouriteAccomodationsId,
                        principalSchema: "accomodaton",
                        principalTable: "Accommodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestFavouriteAccomodation_Guest_GuestId",
                        column: x => x.GuestId,
                        principalSchema: "accomodaton",
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestVisitedAccomodation",
                schema: "accomodaton",
                columns: table => new
                {
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitedAccomodationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestVisitedAccomodation", x => new { x.GuestId, x.AccomodationId });
                    table.ForeignKey(
                        name: "FK_GuestVisitedAccomodation_Accommodation_VisitedAccomodationsId",
                        column: x => x.VisitedAccomodationsId,
                        principalSchema: "accomodaton",
                        principalTable: "Accommodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestVisitedAccomodation_Guest_GuestId",
                        column: x => x.GuestId,
                        principalSchema: "accomodaton",
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceChangeTrack",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewPrice_Ammount = table.Column<double>(type: "float", nullable: false),
                    NewPrice_Currency = table.Column<int>(type: "int", nullable: false),
                    OldPrice_Ammount = table.Column<double>(type: "float", nullable: false),
                    OldPrice_Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceChangeTrack", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestFavouriteAccomodation_FavouriteAccomodationsId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation",
                column: "FavouriteAccomodationsId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestFavouriteAccomodation_GuestId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestVisitedAccomodation_VisitedAccomodationsId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation",
                column: "VisitedAccomodationsId");
        }
    }
}
