using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class adduseravatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9eeec111-adb5-47f9-9d61-7ba88cb3ab5f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cd08c4d1-98c2-4091-8b94-65ea4f1242ea");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Notifications");

            migrationBuilder.AddColumn<string>(
                name: "AvatarUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6255), new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6254) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6257), new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6257) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6258), new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6258) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6259), new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6259) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6260), new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6259) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6260), new DateTime(2023, 12, 16, 17, 18, 20, 328, DateTimeKind.Utc).AddTicks(6260) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "46084d55-95d3-45d1-a3fd-4ae7dcc82b0b", "0adc8f5e-c902-4ae5-91f6-23c78ad4fd58", "User", "USER" },
                    { "ccc3b31b-fd2d-49c4-acca-4728482e7d19", "c7564a99-f6ba-490a-93b7-889ba7a50e9e", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "46084d55-95d3-45d1-a3fd-4ae7dcc82b0b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ccc3b31b-fd2d-49c4-acca-4728482e7d19");

            migrationBuilder.DropColumn(
                name: "AvatarUrl",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1513), new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1511) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1515), new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1515) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1516), new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1516) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1517), new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1518), new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1517) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1518), new DateTime(2023, 12, 14, 17, 19, 25, 835, DateTimeKind.Utc).AddTicks(1518) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9eeec111-adb5-47f9-9d61-7ba88cb3ab5f", "5be6835a-813d-42ec-baa4-19c4bc16d1ef", "User", "USER" },
                    { "cd08c4d1-98c2-4091-8b94-65ea4f1242ea", "7e9f6c2b-ff47-4157-9f58-0b477e082767", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
