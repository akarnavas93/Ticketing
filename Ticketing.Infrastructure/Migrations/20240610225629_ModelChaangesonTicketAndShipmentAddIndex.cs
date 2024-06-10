using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModelChaangesonTicketAndShipmentAddIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Shipments_ShipmentId",
                schema: "core",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_ActionUserId",
                schema: "core",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_CreateUserId",
                schema: "core",
                table: "Tickets");

            migrationBuilder.AddColumn<int>(
                name: "Carrier",
                schema: "application",
                table: "Shipments",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_TrackingNumber_Carrier",
                schema: "application",
                table: "Shipments",
                columns: new[] { "TrackingNumber", "Carrier" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Shipments_ShipmentId",
                schema: "core",
                table: "Tickets",
                column: "ShipmentId",
                principalSchema: "application",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_ActionUserId",
                schema: "core",
                table: "Tickets",
                column: "ActionUserId",
                principalSchema: "accounts",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreateUserId",
                schema: "core",
                table: "Tickets",
                column: "CreateUserId",
                principalSchema: "accounts",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Shipments_ShipmentId",
                schema: "core",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_ActionUserId",
                schema: "core",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_CreateUserId",
                schema: "core",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_TrackingNumber_Carrier",
                schema: "application",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "Carrier",
                schema: "application",
                table: "Shipments");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Shipments_ShipmentId",
                schema: "core",
                table: "Tickets",
                column: "ShipmentId",
                principalSchema: "application",
                principalTable: "Shipments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_ActionUserId",
                schema: "core",
                table: "Tickets",
                column: "ActionUserId",
                principalSchema: "accounts",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Users_CreateUserId",
                schema: "core",
                table: "Tickets",
                column: "CreateUserId",
                principalSchema: "accounts",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
