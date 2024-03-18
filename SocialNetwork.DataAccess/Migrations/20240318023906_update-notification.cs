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
                keyValue: "47d4f135-c0aa-4af4-bd36-e7f2a1983b99");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b03c9b70-b84b-4bf3-85e5-96b44f30bd0f");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "FromUserId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "Seen",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "TargetUserId",
                table: "Notifications",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_TargetUserId",
                table: "Notifications",
                newName: "IX_Notifications_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "NotifiableId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "NotifiableType",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReadAt",
                table: "Notifications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NotificationDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
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
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4638), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4642) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4647), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4647) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4648), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(4649) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5151), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5155), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5156) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5624), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5624) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5628), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5628) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5629), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5630) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5630), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5631) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5631), new DateTime(2024, 3, 18, 2, 39, 5, 948, DateTimeKind.Utc).AddTicks(5632) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4856), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4859) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4866), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4866) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4868), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4868) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4869), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4870) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4871), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4871) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4874), new DateTime(2024, 3, 18, 2, 39, 5, 955, DateTimeKind.Utc).AddTicks(4875) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7097bb45-a3f3-4650-aece-60ca9368e24b", "af8ae957-362e-447b-badb-7c657dab9879", "Administrator", "ADMINISTRATOR" },
                    { "7abf4b13-5374-4d5a-88f9-b9a479f8c4f1", "368309e3-31e6-4ebb-89b2-e4eb94fac030", "User", "USER" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "NotificationDetails");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7097bb45-a3f3-4650-aece-60ca9368e24b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7abf4b13-5374-4d5a-88f9-b9a479f8c4f1");

            migrationBuilder.DropColumn(
                name: "NotifiableId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotifiableType",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ReadAt",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Notifications",
                newName: "TargetUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                newName: "IX_Notifications_TargetUserId");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FromUserId",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Seen",
                table: "Notifications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(5475), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(5480) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(5484), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(5484) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(5485), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6074), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6075) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6077), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6078) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6439), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6440) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6448), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6449) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6450), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6451) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6451), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6452), new DateTime(2024, 3, 8, 15, 15, 3, 76, DateTimeKind.Utc).AddTicks(6452) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(283), new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(286) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(295), new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(295) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(296), new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(297) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(298), new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(298) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(299), new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(299) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(301), new DateTime(2024, 3, 8, 15, 15, 3, 84, DateTimeKind.Utc).AddTicks(302) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "47d4f135-c0aa-4af4-bd36-e7f2a1983b99", "7c9cfdc4-8b07-4cbb-b8b7-e0726c48f53a", "Administrator", "ADMINISTRATOR" },
                    { "b03c9b70-b84b-4bf3-85e5-96b44f30bd0f", "77c5c854-9cf3-4ee6-81cf-6e0be7e7276b", "User", "USER" }
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
    }
}
