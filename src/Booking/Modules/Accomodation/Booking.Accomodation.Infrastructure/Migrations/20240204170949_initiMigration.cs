using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Accomodation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initiMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "accomodaton");

            migrationBuilder.CreateTable(
                name: "AvailabilityPeriodChangeTrack",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldTimeSlot_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldTimeSlot_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewTimeSlot_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewTimeSlot_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvailabilityPeriodId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityPeriodChangeTrack", x => x.Id);
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
                name: "Guest",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Host",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceChangeTrack",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceChangeTrack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accomodation",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinGuests = table.Column<int>(type: "int", nullable: false),
                    MaxGuests = table.Column<int>(type: "int", nullable: false),
                    isBlocked = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "AvailabilityPeriod",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeSlot_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeSlot_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvailabilityPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AvailabilityPeriod_Accomodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accomodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestFavouriteAccomodation",
                schema: "accomodaton",
                columns: table => new
                {
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestFavouriteAccomodation", x => new { x.AccomodationId, x.GuestId });
                    table.ForeignKey(
                        name: "FK_GuestFavouriteAccomodation_Accomodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accomodation",
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
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestVisitedAccomodation", x => new { x.GuestId, x.AccomodationId });
                    table.ForeignKey(
                        name: "FK_GuestVisitedAccomodation_Accomodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accomodation",
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
                name: "Photo",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "Reservation",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeSlot_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeSlot_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GuestNumber = table.Column<int>(type: "int", nullable: false),
                    GustId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_Accomodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accomodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationRequest",
                schema: "accomodaton",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeSlot_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeSlot_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    GuestNumber = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationRequest_Accomodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalSchema: "accomodaton",
                        principalTable: "Accomodation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationRequest_Guest_GuestId",
                        column: x => x.GuestId,
                        principalSchema: "accomodaton",
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_AvailabilityPeriod_AccomodationId",
                schema: "accomodaton",
                table: "AvailabilityPeriod",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Name",
                schema: "accomodaton",
                table: "Facility",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_UserId",
                schema: "accomodaton",
                table: "Guest",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GuestFavouriteAccomodation_GuestId",
                schema: "accomodaton",
                table: "GuestFavouriteAccomodation",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestVisitedAccomodation_AccomodationId",
                schema: "accomodaton",
                table: "GuestVisitedAccomodation",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Host_UserId",
                schema: "accomodaton",
                table: "Host",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Photo_AccomodationId",
                schema: "accomodaton",
                table: "Photo",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_AccomodationId",
                schema: "accomodaton",
                table: "Reservation",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRequest_AccomodationId",
                schema: "accomodaton",
                table: "ReservationRequest",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRequest_GuestId",
                schema: "accomodaton",
                table: "ReservationRequest",
                column: "GuestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccomodationFacility",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "AvailabilityPeriod",
                schema: "accomodaton");

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
                name: "Photo",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "PriceChangeTrack",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "ReservationRequest",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Facility",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Accomodation",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Guest",
                schema: "accomodaton");

            migrationBuilder.DropTable(
                name: "Host",
                schema: "accomodaton");
        }
    }
}
