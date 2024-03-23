using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserIdFromEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Subscriber_HostId",
                schema: "commerce",
                table: "Subscriber");

            migrationBuilder.DropIndex(
                name: "IX_Payer_PayerId",
                schema: "commerce",
                table: "Payer");

            migrationBuilder.DropColumn(
                name: "HostId",
                schema: "commerce",
                table: "Subscriber");

            migrationBuilder.DropColumn(
                name: "PayerId",
                schema: "commerce",
                table: "Payer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HostId",
                schema: "commerce",
                table: "Subscriber",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PayerId",
                schema: "commerce",
                table: "Payer",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Subscriber_HostId",
                schema: "commerce",
                table: "Subscriber",
                column: "HostId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payer_PayerId",
                schema: "commerce",
                table: "Payer",
                column: "PayerId",
                unique: true);
        }
    }
}
