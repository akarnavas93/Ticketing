using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticketing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddShipmentSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "application",
                table: "Shipments",
                columns: new[] { "Id", "ArrivedAt", "Carrier", "Created", "CurrentStatusStartedAt", "ShippedAt", "Status", "TrackingNumber", "Updated" },
                values: new object[,]
                {
                    { new Guid("2f7dcf39-6acf-4d86-99b6-77f43e4640ea"), null, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(580), new TimeSpan(0, 0, 0, 0, 0)), null, 0, "GR455115566874", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4a204506-2e69-4fd3-b094-cd10958bb9aa"), null, 0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(587), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 9, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(588), new TimeSpan(0, 0, 0, 0, 0)), 2, "RT4558654654654", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("633af550-199e-4f6a-9f0b-2bbdb8bfa54a"), null, 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(584), new TimeSpan(0, 0, 0, 0, 0)), 1, "GR455115566874", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a0d8f874-0f67-4768-ab62-81813c0cc4cc"), null, 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(607), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 8, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(608), new TimeSpan(0, 0, 0, 0, 0)), 3, "GR455115566874", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b1fd90e6-de43-4593-89fe-c229cf31fb06"), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(605), new TimeSpan(0, 0, 0, 0, 0)), 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 11, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(604), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2024, 6, 9, 17, 44, 24, 370, DateTimeKind.Unspecified).AddTicks(604), new TimeSpan(0, 0, 0, 0, 0)), 4, "FR566546548864", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("2f7dcf39-6acf-4d86-99b6-77f43e4640ea"));

            migrationBuilder.DeleteData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("4a204506-2e69-4fd3-b094-cd10958bb9aa"));

            migrationBuilder.DeleteData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("633af550-199e-4f6a-9f0b-2bbdb8bfa54a"));

            migrationBuilder.DeleteData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("a0d8f874-0f67-4768-ab62-81813c0cc4cc"));

            migrationBuilder.DeleteData(
                schema: "application",
                table: "Shipments",
                keyColumn: "Id",
                keyValue: new Guid("b1fd90e6-de43-4593-89fe-c229cf31fb06"));
        }
    }
}
