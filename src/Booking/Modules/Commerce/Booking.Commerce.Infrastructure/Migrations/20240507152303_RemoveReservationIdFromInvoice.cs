using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveReservationIdFromInvoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationInvoice_SubscriptionPayment_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice");

            migrationBuilder.DropIndex(
                name: "IX_ReservationInvoice_ReservationId",
                schema: "commerce",
                table: "ReservationInvoice");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                schema: "commerce",
                table: "ReservationInvoice");

            migrationBuilder.RenameColumn(
                name: "Price_Currency",
                schema: "commerce",
                table: "ReservationInvoice",
                newName: "SumPrice_Currency");

            migrationBuilder.RenameColumn(
                name: "Price_Ammount",
                schema: "commerce",
                table: "ReservationInvoice",
                newName: "SumPrice_Ammount");

            migrationBuilder.RenameColumn(
                name: "BookingFee_MoneyToKeepByPlatfomr",
                schema: "commerce",
                table: "ReservationInvoice",
                newName: "BookingFee_MoneyToKeepByPlatform");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationInvoice_ReservationPayment_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice",
                column: "PaymentId",
                principalSchema: "commerce",
                principalTable: "ReservationPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationInvoice_ReservationPayment_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice");

            migrationBuilder.RenameColumn(
                name: "SumPrice_Currency",
                schema: "commerce",
                table: "ReservationInvoice",
                newName: "Price_Currency");

            migrationBuilder.RenameColumn(
                name: "SumPrice_Ammount",
                schema: "commerce",
                table: "ReservationInvoice",
                newName: "Price_Ammount");

            migrationBuilder.RenameColumn(
                name: "BookingFee_MoneyToKeepByPlatform",
                schema: "commerce",
                table: "ReservationInvoice",
                newName: "BookingFee_MoneyToKeepByPlatfomr");

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                schema: "commerce",
                table: "ReservationInvoice",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInvoice_ReservationId",
                schema: "commerce",
                table: "ReservationInvoice",
                column: "ReservationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationInvoice_SubscriptionPayment_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice",
                column: "PaymentId",
                principalSchema: "commerce",
                principalTable: "SubscriptionPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
