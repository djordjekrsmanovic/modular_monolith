using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeyInReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservation_ReservationId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ReservationId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservation_ProductId",
                schema: "commerce",
                table: "Payment",
                column: "ProductId",
                principalSchema: "commerce",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservation_ProductId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                schema: "commerce",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ReservationId",
                schema: "commerce",
                table: "Payment",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservation_ReservationId",
                schema: "commerce",
                table: "Payment",
                column: "ReservationId",
                principalSchema: "commerce",
                principalTable: "Reservation",
                principalColumn: "Id");
        }
    }
}
