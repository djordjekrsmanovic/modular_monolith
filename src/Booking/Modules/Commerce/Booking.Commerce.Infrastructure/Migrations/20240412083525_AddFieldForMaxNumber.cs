using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldForMaxNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionInvoice_Subscription_SubscriptionId",
                schema: "commerce",
                table: "SubscriptionInvoice");

            migrationBuilder.DropIndex(
                name: "IX_SubscriptionInvoice_SubscriptionId",
                schema: "commerce",
                table: "SubscriptionInvoice");

            migrationBuilder.AddColumn<double>(
                name: "Price_Ammount",
                schema: "commerce",
                table: "SubscriptionPlan",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                schema: "commerce",
                table: "SubscriptionPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "durationInMonths",
                schema: "commerce",
                table: "SubscriptionPlan",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price_Ammount",
                schema: "commerce",
                table: "SubscriptionInvoice",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                schema: "commerce",
                table: "SubscriptionInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Price_Ammount",
                schema: "commerce",
                table: "ReservationInvoice",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Price_Currency",
                schema: "commerce",
                table: "ReservationInvoice",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Amount_Ammount",
                schema: "commerce",
                table: "Payment",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Amount_Currency",
                schema: "commerce",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "commerce",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionId",
                schema: "commerce",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SubscriptionId",
                schema: "commerce",
                table: "Payment",
                column: "SubscriptionId");

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
                name: "FK_Payment_Subscription_SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Price_Ammount",
                schema: "commerce",
                table: "SubscriptionPlan");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                schema: "commerce",
                table: "SubscriptionPlan");

            migrationBuilder.DropColumn(
                name: "durationInMonths",
                schema: "commerce",
                table: "SubscriptionPlan");

            migrationBuilder.DropColumn(
                name: "Price_Ammount",
                schema: "commerce",
                table: "SubscriptionInvoice");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                schema: "commerce",
                table: "SubscriptionInvoice");

            migrationBuilder.DropColumn(
                name: "Price_Ammount",
                schema: "commerce",
                table: "ReservationInvoice");

            migrationBuilder.DropColumn(
                name: "Price_Currency",
                schema: "commerce",
                table: "ReservationInvoice");

            migrationBuilder.DropColumn(
                name: "Amount_Ammount",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "Amount_Currency",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoice_SubscriptionId",
                schema: "commerce",
                table: "SubscriptionInvoice",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionInvoice_Subscription_SubscriptionId",
                schema: "commerce",
                table: "SubscriptionInvoice",
                column: "SubscriptionId",
                principalSchema: "commerce",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
