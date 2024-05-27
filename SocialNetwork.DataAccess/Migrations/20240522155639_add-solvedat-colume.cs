using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addsolvedatcolume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0e07abea-2b70-43e5-845e-8c9e0630b566");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1b78caa6-71f6-49d1-9d65-43da7f25dbe4");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a95e4b36-c9d8-4848-9cd9-d60677692501");

            migrationBuilder.AddColumn<DateTime>(
                name: "SolvedAt",
                table: "ReportViolations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6658), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6661) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6673), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6674) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6675), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6676) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6677), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6677) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6679), new DateTime(2024, 5, 22, 15, 56, 38, 536, DateTimeKind.Utc).AddTicks(6679) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(6999), new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7001) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7005), new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7006) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7332), new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7332) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7336), new DateTime(2024, 5, 22, 15, 56, 38, 544, DateTimeKind.Utc).AddTicks(7336) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3948), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3951) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3956), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3956) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3957), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3958) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3958), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3959) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3960), new DateTime(2024, 5, 22, 15, 56, 38, 550, DateTimeKind.Utc).AddTicks(3960) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(504), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(506) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(511), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(511) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(512), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(513) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(514), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(514) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(515), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(515) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(518), new DateTime(2024, 5, 22, 15, 56, 38, 558, DateTimeKind.Utc).AddTicks(518) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02da6001-8dd8-4891-9da3-17e441ab60ce", "9aae8c01-81c9-4cf5-8175-bc40747555cf", "Administrator", "ADMINISTRATOR" },
                    { "2ea08341-a424-4787-a855-00fd272410f3", "21a8c2fb-4bf0-4391-ad56-c4fbb677d3c3", "User", "USER" },
                    { "b39b6d60-64f3-40e4-a382-78b82b667235", "532831fa-b35e-4992-8af7-80e2c2340859", "SuperAdministrator", "SUPERADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "02da6001-8dd8-4891-9da3-17e441ab60ce");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2ea08341-a424-4787-a855-00fd272410f3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b39b6d60-64f3-40e4-a382-78b82b667235");

            migrationBuilder.DropColumn(
                name: "SolvedAt",
                table: "ReportViolations");

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(131), new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(133) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(138), new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(138) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(138), new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(139) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(139), new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "ActionReports",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(140), new DateTime(2024, 5, 21, 1, 37, 32, 949, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3010), new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3011) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3014), new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3015) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3390), new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3393), new DateTime(2024, 5, 21, 1, 37, 32, 953, DateTimeKind.Utc).AddTicks(3393) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2916), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2917) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2921), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2921) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2922), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2922) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2923), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2923) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2923), new DateTime(2024, 5, 21, 1, 37, 32, 957, DateTimeKind.Utc).AddTicks(2924) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2024), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2031), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2032), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2032) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2033), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2035), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2035) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2038), new DateTime(2024, 5, 21, 1, 37, 32, 965, DateTimeKind.Utc).AddTicks(2038) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e07abea-2b70-43e5-845e-8c9e0630b566", "29c0a33b-f0bc-406d-a9e1-c1ba8882f6d9", "Administrator", "ADMINISTRATOR" },
                    { "1b78caa6-71f6-49d1-9d65-43da7f25dbe4", "843fd906-f280-48d3-9ece-3157a3523b4e", "User", "USER" },
                    { "a95e4b36-c9d8-4848-9cd9-d60677692501", "ec1f94b3-c0ba-4329-9c67-65ee9ee8ce65", "SuperAdministrator", "SUPERADMINISTRATOR" }
                });
        }
    }
}
