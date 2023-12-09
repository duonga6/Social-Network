using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComment_User",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostImage_Image",
                table: "PostImages");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User",
                table: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1fc9fb27-d5dc-45fa-b2d9-66b001c3b277");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "21704e94-c029-4184-9c56-88241ccde936");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_PostComment_User",
                table: "PostComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostImage_Image",
                table: "PostImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostComment_User",
                table: "PostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_PostImage_Image",
                table: "PostImages");

            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_User",
                table: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1e2be407-a045-49fb-8378-c0816d762a78");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "74750a9b-e5a2-44b5-ba1b-9e438443c093");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Users");

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
                name: "FK_PostComment_User",
                table: "PostComments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostImage_Image",
                table: "PostImages",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_User",
                table: "RefreshTokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
