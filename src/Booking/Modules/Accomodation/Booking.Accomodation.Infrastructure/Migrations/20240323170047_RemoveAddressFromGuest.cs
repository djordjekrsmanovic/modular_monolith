using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Accomodation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddressFromGuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "accomodaton",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "accomodaton",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                schema: "accomodaton",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Address_State",
                schema: "accomodaton",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "accomodaton",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                schema: "accomodaton",
                table: "Accomodation");

            migrationBuilder.DropColumn(
                name: "Address_State",
                schema: "accomodaton",
                table: "Accomodation");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "accomodaton",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "accomodaton",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                schema: "accomodaton",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                schema: "accomodaton",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "accomodaton",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                schema: "accomodaton",
                table: "Accomodation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                schema: "accomodaton",
                table: "Accomodation",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
