using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Booking.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RedefinePermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "GetHostReservations");

            migrationBuilder.UpdateData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "GetGuestReservations");

            migrationBuilder.UpdateData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "GuestReservationOperations");

            migrationBuilder.InsertData(
                schema: "user_access",
                table: "Permission",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "HostReservationOperations" },
                    { 5, "HostAccommodationOperations" },
                    { 6, "ChangeUserInfo" }
                });

            migrationBuilder.InsertData(
                schema: "user_access",
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 6, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "ReadMember");

            migrationBuilder.UpdateData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "UpdateMember");

            migrationBuilder.UpdateData(
                schema: "user_access",
                table: "Permission",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "GetHostReservations");

            migrationBuilder.InsertData(
                schema: "user_access",
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 1, 2 });
        }
    }
}
