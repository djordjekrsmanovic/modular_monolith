using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeparateTablesForPayments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationInvoice_Payment_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionInvoice_Payment_PaymentId",
                schema: "commerce",
                table: "SubscriptionInvoice");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "commerce");

            migrationBuilder.CreateTable(
                name: "ReservationPayment",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutonTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount_Ammount = table.Column<double>(type: "float", nullable: false),
                    Amount_Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationPayment_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalSchema: "commerce",
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPayment",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutonTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount_Ammount = table.Column<double>(type: "float", nullable: false),
                    Amount_Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionPayment_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "commerce",
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationPayment_ReservationId",
                schema: "commerce",
                table: "ReservationPayment",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionPayment_SubscriptionId",
                schema: "commerce",
                table: "SubscriptionPayment",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationInvoice_SubscriptionPayment_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice",
                column: "PaymentId",
                principalSchema: "commerce",
                principalTable: "SubscriptionPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionInvoice_SubscriptionPayment_PaymentId",
                schema: "commerce",
                table: "SubscriptionInvoice",
                column: "PaymentId",
                principalSchema: "commerce",
                principalTable: "SubscriptionPayment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationInvoice_SubscriptionPayment_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice");

            migrationBuilder.DropForeignKey(
                name: "FK_SubscriptionInvoice_SubscriptionPayment_PaymentId",
                schema: "commerce",
                table: "SubscriptionInvoice");

            migrationBuilder.DropTable(
                name: "ReservationPayment",
                schema: "commerce");

            migrationBuilder.DropTable(
                name: "SubscriptionPayment",
                schema: "commerce");

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutonTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    PaymentType = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Amount_Ammount = table.Column<double>(type: "float", nullable: false),
                    Amount_Currency = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_Reservation_ReservationId",
                        column: x => x.ReservationId,
                        principalSchema: "commerce",
                        principalTable: "Reservation",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "commerce",
                        principalTable: "Subscription",
                        principalColumn: "Id");
                });

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
                name: "FK_ReservationInvoice_Payment_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice",
                column: "PaymentId",
                principalSchema: "commerce",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubscriptionInvoice_Payment_PaymentId",
                schema: "commerce",
                table: "SubscriptionInvoice",
                column: "PaymentId",
                principalSchema: "commerce",
                principalTable: "Payment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
