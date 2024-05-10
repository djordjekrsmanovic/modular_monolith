using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGetHostReservationsPermission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "user_access",
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "GetHostReservations" });

            migrationBuilder.InsertData(
                schema: "user_access",
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
