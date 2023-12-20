using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatenotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "46084d55-95d3-45d1-a3fd-4ae7dcc82b0b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ccc3b31b-fd2d-49c4-acca-4728482e7d19");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "TargetUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_TargetUserId");

            migrationBuilder.AddColumn<string>(
                name: "FromUserId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6228), new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6227) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6230), new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6229) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6230), new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6230) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6231), new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6231) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6232), new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6232) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6233), new DateTime(2023, 12, 17, 7, 25, 13, 233, DateTimeKind.Utc).AddTicks(6232) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95d35b23-9f38-446e-adae-afc208e10d01", "480422ca-8825-4457-9831-f9b00ba58ab1", "Administrator", "ADMINISTRATOR" },
                    { "99d7e20f-5a45-4fb0-ae27-1d7dec2982b0", "98c87404-3467-4c76-bb89-57c6e1a149dd", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FromUserId",
                table: "Notifications",
                column: "FromUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_FromUserId",
                table: "Notifications",
                column: "FromUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_TargetUserId",
                table: "Notifications",
                column: "TargetUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_FromUserId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_TargetUserId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_FromUserId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "95d35b23-9f38-446e-adae-afc208e10d01");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "99d7e20f-5a45-4fb0-ae27-1d7dec2982b0");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "TargetUserId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_TargetUserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
