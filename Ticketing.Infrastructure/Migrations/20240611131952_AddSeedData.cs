using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ticketing.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "accounts",
                table: "Users",
                columns: new[] { "Id", "AccountType", "Created", "Email", "Name", "PasswordHash", "PasswordSalt", "Updated" },
                values: new object[,]
                {
                    { new Guid("0afe7827-a0cf-47d4-9820-488d84b894b0"), (byte)1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "operations@bar.com", "foo", "y0hJNdP2TNzYp1JrFnO/PhrGL7BI567/OskMBZ/bjBzmlQND1AO3bTiYFTGlGcMmDRNfUbOVLytbH+K3k2FjYw==", "6MonNb30kVohmzyk6hvpm9Pn7x66ATPe7DbEhUqeHAPZtL5xS8D29xEfs9lewyMKBQzAiYCH2aH5FpgH+Edd3Ov5Qk+rImsGdiN49W43SafAXsx5XFmRJs1UrJV6HgA70GrLpoZ//MJVH7DoKw7E8i1YhsIIzXb9m1Xr6EVGlYk=", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("30b3e2db-213c-4519-8dee-83b70133db35"), (byte)2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "it@bar.com", "bar", "y0hJNdP2TNzYp1JrFnO/PhrGL7BI567/OskMBZ/bjBzmlQND1AO3bTiYFTGlGcMmDRNfUbOVLytbH+K3k2FjYw==", "6MonNb30kVohmzyk6hvpm9Pn7x66ATPe7DbEhUqeHAPZtL5xS8D29xEfs9lewyMKBQzAiYCH2aH5FpgH+Edd3Ov5Qk+rImsGdiN49W43SafAXsx5XFmRJs1UrJV6HgA70GrLpoZ//MJVH7DoKw7E8i1YhsIIzXb9m1Xr6EVGlYk=", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("df862849-2e4b-4f54-ae81-a8b55cf2fd17"), (byte)0, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "undefined@bar.com", "foobar", "y0hJNdP2TNzYp1JrFnO/PhrGL7BI567/OskMBZ/bjBzmlQND1AO3bTiYFTGlGcMmDRNfUbOVLytbH+K3k2FjYw==", "6MonNb30kVohmzyk6hvpm9Pn7x66ATPe7DbEhUqeHAPZtL5xS8D29xEfs9lewyMKBQzAiYCH2aH5FpgH+Edd3Ov5Qk+rImsGdiN49W43SafAXsx5XFmRJs1UrJV6HgA70GrLpoZ//MJVH7DoKw7E8i1YhsIIzXb9m1Xr6EVGlYk=", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "accounts",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0afe7827-a0cf-47d4-9820-488d84b894b0"));

            migrationBuilder.DeleteData(
                schema: "accounts",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("30b3e2db-213c-4519-8dee-83b70133db35"));

            migrationBuilder.DeleteData(
                schema: "accounts",
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("df862849-2e4b-4f54-ae81-a8b55cf2fd17"));
        }
    }
}
