using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ticketing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyTicketAddTicketStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Status",
                schema: "core",
                table: "Tickets",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("2f7dcf39-6acf-4d86-99b6-77f43e4640ea"),
                column: "CurrentStatusStartedAt",
                value: new DateTimeOffset(new DateTime(2024, 6, 11, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2024), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("4a204506-2e69-4fd3-b094-cd10958bb9aa"),
                columns: new[] { "CurrentStatusStartedAt", "ShippedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 6, 11, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2031), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 9, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2032), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("633af550-199e-4f6a-9f0b-2bbdb8bfa54a"),
                columns: new[] { "CurrentStatusStartedAt", "ShippedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 6, 11, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2027), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2028), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("a0d8f874-0f67-4768-ab62-81813c0cc4cc"),
                columns: new[] { "CurrentStatusStartedAt", "ShippedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 6, 11, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2058), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 8, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2059), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("b1fd90e6-de43-4593-89fe-c229cf31fb06"),
                columns: new[] { "ArrivedAt", "CurrentStatusStartedAt", "ShippedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 6, 11, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2056), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2054), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 9, 20, 26, 47, 271, DateTimeKind.Unspecified).AddTicks(2055), new TimeSpan(0, 0, 0, 0, 0)) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "core",
                table: "Tickets");

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("2f7dcf39-6acf-4d86-99b6-77f43e4640ea"),
                column: "CurrentStatusStartedAt",
                value: new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(580), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("4a204506-2e69-4fd3-b094-cd10958bb9aa"),
                columns: new[] { "CurrentStatusStartedAt", "ShippedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 9, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(588), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("633af550-199e-4f6a-9f0b-2bbdb8bfa54a"),
                columns: new[] { "CurrentStatusStartedAt", "ShippedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("a0d8f874-0f67-4768-ab62-81813c0cc4cc"),
                columns: new[] { "CurrentStatusStartedAt", "ShippedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(607), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 8, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(608), new TimeSpan(0, 0, 0, 0, 0)) });

            migrationBuilder.UpdateData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("b1fd90e6-de43-4593-89fe-c229cf31fb06"),
                columns: new[] { "ArrivedAt", "CurrentStatusStartedAt", "ShippedAt" },
                values: new object[] { new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(604), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 9, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(604), new TimeSpan(0, 0, 0, 0, 0)) });
        }
    }
}
