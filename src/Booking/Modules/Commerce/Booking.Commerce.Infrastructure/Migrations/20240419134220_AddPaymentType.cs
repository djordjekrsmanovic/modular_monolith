using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Subscription_SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Subscriber_SubscriberId",
                schema: "commerce",
                table: "Subscription");

            migrationBuilder.DropIndex(
                name: "IX_Payment_SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "durationInMonths",
                schema: "commerce",
                table: "SubscriptionPlan",
                newName: "DurationInMonths");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriberId",
                schema: "commerce",
                table: "Subscription",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                schema: "commerce",
                table: "Payment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ProductId",
                schema: "commerce",
                table: "Payment",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Subscription_ProductId",
                schema: "commerce",
                table: "Payment",
                column: "ProductId",
                principalSchema: "commerce",
                principalTable: "Subscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Subscriber_SubscriberId",
                schema: "commerce",
                table: "Subscription",
                column: "SubscriberId",
                principalSchema: "commerce",
                principalTable: "Subscriber",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Subscription_ProductId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_Subscriber_SubscriberId",
                schema: "commerce",
                table: "Subscription");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ProductId",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                schema: "commerce",
                table: "Payment");

            migrationBuilder.RenameColumn(
                name: "DurationInMonths",
                schema: "commerce",
                table: "SubscriptionPlan",
                newName: "durationInMonths");

            migrationBuilder.AlterColumn<Guid>(
                name: "SubscriberId",
                schema: "commerce",
                table: "Subscription",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_Subscriber_SubscriberId",
                schema: "commerce",
                table: "Subscription",
                column: "SubscriberId",
                principalSchema: "commerce",
                principalTable: "Subscriber",
                principalColumn: "Id");
        }
    }
}
