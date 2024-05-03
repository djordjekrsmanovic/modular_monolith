using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveForeignKeyFromPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservation_ProductId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Subscription_ProductId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ProductId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationId",
                schema: "commerce",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionId",
                schema: "commerce",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ReservationId",
                schema: "commerce",
                table: "Payment",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SubscriptionId",
                schema: "commerce",
                table: "Payment",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservation_ReservationId",
                schema: "commerce",
                table: "Payment",
                column: "ReservationId",
                principalSchema: "commerce",
                principalTable: "Reservation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Subscription_SubscriptionId",
                schema: "commerce",
                table: "Payment",
                column: "SubscriptionId",
                principalSchema: "commerce",
                principalTable: "Subscription",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Reservation_ReservationId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Subscription_SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ReservationId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ProductId",
                schema: "commerce",
                table: "Payment",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Reservation_ProductId",
                schema: "commerce",
                table: "Payment",
                column: "ProductId",
                principalSchema: "commerce",
                principalTable: "Reservation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Subscription_ProductId",
                schema: "commerce",
                table: "Payment",
                column: "ProductId",
                principalSchema: "commerce",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
