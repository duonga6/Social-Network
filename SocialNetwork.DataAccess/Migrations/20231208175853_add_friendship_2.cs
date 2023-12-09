using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class add_friendship_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_UserId1",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_UserId2",
                table: "Friendships");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "17a1064b-1e56-4c73-847e-8742b6b6068d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8557ab77-fc9f-4355-8a95-870c4b879aa5");

            migrationBuilder.RenameColumn(
                name: "UserId2",
                table: "Friendships",
                newName: "TargetUserId");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Friendships",
                newName: "RequestUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_UserId2",
                table: "Friendships",
                newName: "IX_Friendships_TargetUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_UserId1",
                table: "Friendships",
                newName: "IX_Friendships_RequestUserId");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7559), new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7553) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7561), new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7560) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7561), new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7561) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7562), new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7563), new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7563) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7564), new DateTime(2023, 12, 8, 17, 58, 53, 351, DateTimeKind.Utc).AddTicks(7563) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1fc9fb27-d5dc-45fa-b2d9-66b001c3b277", "6b68abdd-f3f3-4567-979f-975436d29e62", "Administrator", "ADMINISTRATOR" },
                    { "21704e94-c029-4184-9c56-88241ccde936", "9df01bd4-8422-44ff-9abd-a79e98f6f00a", "User", "USER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_RequestUserId",
                table: "Friendships",
                column: "RequestUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_TargetUserId",
                table: "Friendships",
                column: "TargetUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_RequestUserId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_TargetUserId",
                table: "Friendships");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1fc9fb27-d5dc-45fa-b2d9-66b001c3b277");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "21704e94-c029-4184-9c56-88241ccde936");

            migrationBuilder.RenameColumn(
                name: "TargetUserId",
                table: "Friendships",
                newName: "UserId2");

            migrationBuilder.RenameColumn(
                name: "RequestUserId",
                table: "Friendships",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_TargetUserId",
                table: "Friendships",
                newName: "IX_Friendships_UserId2");

            migrationBuilder.RenameIndex(
                name: "IX_Friendships_RequestUserId",
                table: "Friendships",
                newName: "IX_Friendships_UserId1");

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2950), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2946) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2952), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2952) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2953), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2953) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2954), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2954) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2955), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2955) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2956), new DateTime(2023, 12, 8, 15, 25, 46, 821, DateTimeKind.Utc).AddTicks(2955) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17a1064b-1e56-4c73-847e-8742b6b6068d", "cfda828f-0136-41ff-af5f-c4cd5163e1cb", "User", "USER" },
                    { "8557ab77-fc9f-4355-8a95-870c4b879aa5", "95d5b6e8-53cf-4ec9-ad67-ff84cb49ffaf", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_UserId1",
                table: "Friendships",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_UserId2",
                table: "Friendships",
                column: "UserId2",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
