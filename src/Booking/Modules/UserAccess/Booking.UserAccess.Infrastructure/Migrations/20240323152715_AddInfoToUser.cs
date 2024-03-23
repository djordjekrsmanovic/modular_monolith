using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddInfoToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "user_access",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "user_access",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "user_access",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "user_access",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                schema: "user_access",
                table: "RegistrationRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                schema: "user_access",
                table: "RegistrationRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_Street",
                schema: "user_access",
                table: "RegistrationRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                schema: "user_access",
                table: "RegistrationRequest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "user_access",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "user_access",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "user_access",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "user_access",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Address_City",
                schema: "user_access",
                table: "RegistrationRequest");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                schema: "user_access",
                table: "RegistrationRequest");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                schema: "user_access",
                table: "RegistrationRequest");

            migrationBuilder.DropColumn(
                name: "Phone",
                schema: "user_access",
                table: "RegistrationRequest");
        }
    }
}
