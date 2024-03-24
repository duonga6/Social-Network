using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatenotificationremovenotificationdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationDetails");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0ffb7a32-699f-40f5-93b4-c51384f24c9a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7d1f4af6-bab9-4a54-9327-f1b590a78da1");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "FromId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_FromId");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JsonDetail",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9437), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9442), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9443), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9789), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9789) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9792), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9792) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2778), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2778) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2781), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2781) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2782), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2782) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2783), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2783) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2784), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2784) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7302), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7311), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7313), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7313) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7314), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7315) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7316), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7316) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7320), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c70e0566-9654-4d4b-9376-7a52b31ecc0e", "5e880f2d-d8ba-4c75-ac8b-295c4cd8ff75", "Administrator", "ADMINISTRATOR" },
                    { "dcaf9706-dbb3-4cc7-a0a5-65e4609df700", "9cdb7fd9-dfc1-41ef-a458-63b243680f75", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ToId",
                table: "Notifications",
                column: "ToId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_FromId",
                table: "Notifications",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_ToId",
                table: "Notifications",
                column: "ToId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_FromId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_ToId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ToId",
                table: "Notifications");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c70e0566-9654-4d4b-9376-7a52b31ecc0e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dcaf9706-dbb3-4cc7-a0a5-65e4609df700");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "JsonDetail",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ToId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "FromId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_FromId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.CreateTable(
                name: "NotificationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationDetails_Notifications_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notifications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NotificationDetails_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6472), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6475) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6478), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6478) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6479), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6480) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6838), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6839) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6842), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(6842) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9738), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9739) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9742), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9742) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9743), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9743) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9744), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9744) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9745), new DateTime(2024, 3, 22, 14, 36, 45, 62, DateTimeKind.Utc).AddTicks(9745) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4469), new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4470) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4473), new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4474) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4475), new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4475) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4476), new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4476) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4477), new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4477) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4479), new DateTime(2024, 3, 22, 14, 36, 45, 67, DateTimeKind.Utc).AddTicks(4479) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ffb7a32-699f-40f5-93b4-c51384f24c9a", "54a52b37-ada8-4e51-b0ef-a8997f3285b7", "Administrator", "ADMINISTRATOR" },
                    { "7d1f4af6-bab9-4a54-9327-f1b590a78da1", "dfc1e4c3-b0f9-4ea3-8d65-01b048826edb", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationDetails_AuthorId",
                table: "NotificationDetails",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationDetails_NotificationId",
                table: "NotificationDetails",
                column: "NotificationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
