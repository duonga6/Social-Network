using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updateuser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1e2be407-a045-49fb-8378-c0816d762a78");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "74750a9b-e5a2-44b5-ba1b-9e438443c093");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8916), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8913) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8917), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8918), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8918) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8919), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8919) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8920), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8919) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8920), new DateTime(2023, 12, 9, 14, 8, 51, 269, DateTimeKind.Utc).AddTicks(8920) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0d463e9c-7f56-486f-a574-f9c657094855", "d86c0866-c570-4292-aadf-789227eb6c5f", "User", "USER" },
                    { "9878da52-b772-4ae3-9a0e-b4b77c817156", "2da30d1f-ce15-410c-8fbc-d91e66fbb4d9", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0d463e9c-7f56-486f-a574-f9c657094855");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9878da52-b772-4ae3-9a0e-b4b77c817156");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1645), new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1642) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1646), new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1646) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1647), new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1647) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1648), new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1649), new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1648) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1649), new DateTime(2023, 12, 9, 14, 7, 36, 804, DateTimeKind.Utc).AddTicks(1649) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e2be407-a045-49fb-8378-c0816d762a78", "09afc23e-e431-422d-a028-ef2dc7009f44", "User", "USER" },
                    { "74750a9b-e5a2-44b5-ba1b-9e438443c093", "c20279aa-21f7-4549-8b2c-25a46006fa0e", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
