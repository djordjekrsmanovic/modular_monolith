using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Accomodation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAddressFromHost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "Address_PostalCode",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "Address_State",
                schema: "accomodaton",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "accomodaton",
                table: "Host");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "accomodaton",
                table: "Host",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "accomodaton",
                table: "Host",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_PostalCode",
                schema: "accomodaton",
                table: "Host",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                schema: "accomodaton",
                table: "Host",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "accomodaton",
                table: "Host",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
