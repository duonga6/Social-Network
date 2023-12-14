using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addnotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c9405156-0ce4-4198-9a37-cd8a2574ea8d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ee704529-f52c-4d0c-a106-9573b9a3790e");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seen = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9eeec111-adb5-47f9-9d61-7ba88cb3ab5f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cd08c4d1-98c2-4091-8b94-65ea4f1242ea");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6745), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6743) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6747), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6747) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6748), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6748) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6749), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6750), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6749) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6750), new DateTime(2023, 12, 14, 14, 26, 45, 980, DateTimeKind.Utc).AddTicks(6750) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c9405156-0ce4-4198-9a37-cd8a2574ea8d", "452422fc-b571-4b34-9002-ba3b68886fc8", "Administrator", "ADMINISTRATOR" },
                    { "ee704529-f52c-4d0c-a106-9573b9a3790e", "4f4f478d-f2aa-4e55-8a80-6c012fa6f947", "User", "USER" }
                });
        }
    }
}
