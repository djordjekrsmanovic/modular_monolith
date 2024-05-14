using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.AccommodationNS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangePhotoToImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailabilityPeriod_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestFavouriteAccomodation_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestVisitedAccomodation_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRequest_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "ReservationRequest");

            migrationBuilder.DropTable(
                name: "AccomodationFacility",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Photo",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Facility",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Accomodation",
                schema: "accomodaton");

            migrationBuilder.DropIndex(
                name: "IX_GuestVisitedAccomodation_AccomodationId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation");

            migrationBuilder.AddColumn<Guid>(
                name: "VisitedAccomodationsId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FavouriteAccomodationsId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Accommodation",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isBlocked = table.Column<bool>(type: "bit", nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Capacity_MaxGuestNumber = table.Column<int>(type: "int", nullable: false),
                    Capacity_MinGuestNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodation_Host_HostId",
                        column: x => x.HostId,
                        principalSchema: "accomodaton",
                        principalTable: "Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalService",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalService", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Accommodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accommodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationAdditionalService",
                schema: "accomodaton",
                columns: table => new
                {
                    AccommodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdditionalServicesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationAdditionalService", x => new { x.AccommodationId, x.AdditionalServicesId });
                    table.ForeignKey(
                        name: "FK_AccommodationAdditionalService_Accommodation_AccommodationId",
                        column: x => x.AccommodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accommodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccommodationAdditionalService_AdditionalService_AdditionalServicesId",
                        column: x => x.AdditionalServicesId,
                        principalSchema: "accomodaton",
                        principalTable: "AdditionalService",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestVisitedAccomodation_VisitedAccomodationsId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation",
                column: "VisitedAccomodationsId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestFavouriteAccomodation_FavouriteAccomodationsId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation",
                column: "FavouriteAccomodationsId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_HostId",
                schema: "accomodaton",
                table: "Accommodation",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationAdditionalService_AdditionalServicesId",
                schema: "accomodaton",
                table: "AccommodationAdditionalService",
                column: "AdditionalServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalService_Name",
                schema: "accomodaton",
                table: "AdditionalService",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Image_AccomodationId",
                schema: "accomodaton",
                table: "Image",
                column: "AccomodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailabilityPeriod_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestFavouriteAccomodation_Accommodation_FavouriteAccomodationsId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation",
                column: "FavouriteAccomodationsId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestVisitedAccomodation_Accommodation_VisitedAccomodationsId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation",
                column: "VisitedAccomodationsId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "Reservation",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRequest_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "ReservationRequest",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailabilityPeriod_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestFavouriteAccomodation_Accommodation_FavouriteAccomodationsId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation");

            migrationBuilder.DropForeignKey(
                name: "FK_GuestVisitedAccomodation_Accommodation_VisitedAccomodationsId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationRequest_Accommodation_AccomodationId",
                schema: "accomodaton",
                table: "ReservationRequest");

            migrationBuilder.DropTable(
                name: "AccommodationAdditionalService",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Image",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "AdditionalService",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Accommodation",
                schema: "accomodaton");

            migrationBuilder.DropIndex(
                name: "IX_GuestVisitedAccomodation_VisitedAccomodationsId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation");

            migrationBuilder.DropIndex(
                name: "IX_GuestFavouriteAccomodation_FavouriteAccomodationsId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation");

            migrationBuilder.DropColumn(
                name: "VisitedAccomodationsId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation");

            migrationBuilder.DropColumn(
                name: "FavouriteAccomodationsId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation");

            migrationBuilder.CreateTable(
                name: "Accomodation",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MaxGuests = table.Column<int>(type: "int", nullable: false),
                    MinGuests = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isBlocked = table.Column<bool>(type: "bit", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accomodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accomodation_Host_HostId",
                        column: x => x.HostId,
                        principalSchema: "accomodaton",
                        principalTable: "Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Photo",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Accomodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accomodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccomodationFacility",
                schema: "accomodaton",
                columns: table => new
                {
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FacilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccomodationFacility", x => new { x.AccomodationId, x.FacilitiesId });
                    table.ForeignKey(
                        name: "FK_AccomodationFacility_Accomodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accomodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccomodationFacility_Facility_FacilitiesId",
                        column: x => x.FacilitiesId,
                        principalSchema: "accomodaton",
                        principalTable: "Facility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestVisitedAccomodation_AccomodationId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Accomodation_HostId",
                schema: "accomodaton",
                table: "Accomodation",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_AccomodationFacility_FacilitiesId",
                schema: "accomodaton",
                table: "AccomodationFacility",
                column: "FacilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Name",
                schema: "accomodaton",
                table: "Facility",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AccomodationId",
                schema: "accomodaton",
                table: "Photo",
                column: "AccomodationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailabilityPeriod_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accomodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestFavouriteAccomodation_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accomodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GuestVisitedAccomodation_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accomodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "Reservation",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accomodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationRequest_Accomodation_AccomodationId",
                schema: "accomodaton",
                table: "ReservationRequest",
                column: "AccomodationId",
                principalSchema: "accomodaton",
                principalTable: "Accomodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
