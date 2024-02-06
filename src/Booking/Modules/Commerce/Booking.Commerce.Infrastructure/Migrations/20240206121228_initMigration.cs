using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.Commerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "commerce");

            migrationBuilder.CreateTable(
                name: "Payer",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutonTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionPlan",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccomodationLimit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionPlan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationInvoice",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingFee_BookingFeePercent = table.Column<double>(type: "float", nullable: false),
                    BookingFee_MoneyToKeepByPlatfomr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReservationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationInvoice_Payer_PayerId",
                        column: x => x.PayerId,
                        principalSchema: "commerce",
                        principalTable: "Payer",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReservationInvoice_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "commerce",
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionPeriod_Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionPeriod_End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    PlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Subscriber_SubscriberId",
                        column: x => x.SubscriberId,
                        principalSchema: "commerce",
                        principalTable: "Subscriber",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Subscription_SubscriptionPlan_PlanId",
                        column: x => x.PlanId,
                        principalSchema: "commerce",
                        principalTable: "SubscriptionPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionInvoice",
                schema: "commerce",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriberId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionInvoice_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalSchema: "commerce",
                        principalTable: "Payment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscriptionInvoice_Subscriber_SubscriberId",
                        column: x => x.SubscriberId,
                        principalSchema: "commerce",
                        principalTable: "Subscriber",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubscriptionInvoice_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "commerce",
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInvoice_PayerId",
                schema: "commerce",
                table: "ReservationInvoice",
                column: "PayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInvoice_PaymentId",
                schema: "commerce",
                table: "ReservationInvoice",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationInvoice_ReservationId",
                schema: "commerce",
                table: "ReservationInvoice",
                column: "ReservationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_PlanId",
                schema: "commerce",
                table: "Subscription",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_SubscriberId",
                schema: "commerce",
                table: "Subscription",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoice_PaymentId",
                schema: "commerce",
                table: "SubscriptionInvoice",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoice_SubscriberId",
                schema: "commerce",
                table: "SubscriptionInvoice",
                column: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionInvoice_SubscriptionId",
                schema: "commerce",
                table: "SubscriptionInvoice",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "commerce");

            migrationBuilder.DropTable(
                name: "ReservationInvoice",
                schema: "commerce");

            migrationBuilder.DropTable(
                name: "SubscriptionInvoice",
                schema: "commerce");

            migrationBuilder.DropTable(
                name: "Payer",
                schema: "commerce");

            migrationBuilder.DropTable(
                name: "Payment",
                schema: "commerce");

            migrationBuilder.DropTable(
                name: "Subscription",
                schema: "commerce");

            migrationBuilder.DropTable(
                name: "Subscriber",
                schema: "commerce");

            migrationBuilder.DropTable(
                name: "SubscriptionPlan",
                schema: "commerce");
        }
    }
}
