using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.UserAccess.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionToGuest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                schema: "user_access",
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "user_access",
                table: "RolePermission",
                keyColumns: new[] { "PermissionId", "RoleId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                schema: "user_access",
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[] { 3, 1 });
        }
    }
}
