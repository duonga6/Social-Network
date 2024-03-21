using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatepostmediaadduserid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4ce6aebd-5511-4a91-9875-311b757cfbb1");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4d5ab5a0-5c73-4b44-a884-15a09601f478");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PostMedias",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4445), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4447) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4450), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4450) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4451), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4451) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4737), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4740), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7730), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7730) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7733), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7733) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7734), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7734) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7735), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7735) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7735), new DateTime(2024, 3, 21, 15, 15, 33, 30, DateTimeKind.Utc).AddTicks(7736) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2069), new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2075) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2079), new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2080) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2081), new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2081) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2082), new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2082) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2082), new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2083) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2084), new DateTime(2024, 3, 21, 15, 15, 33, 35, DateTimeKind.Utc).AddTicks(2085) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ff97448-2d30-45c6-a014-124bda3aafc3", "9ce2a9b8-fc45-4250-bca7-b97431e79259", "Administrator", "ADMINISTRATOR" },
                    { "bf4a90d7-63d6-4ee0-9475-4ace8aa7c5c7", "2d3c2abe-30c8-424e-befd-17022abf6628", "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostMedias_UserId",
                table: "PostMedias",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PostMedias_Users_UserId",
                table: "PostMedias",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostMedias_Users_UserId",
                table: "PostMedias");

            migrationBuilder.DropIndex(
                name: "IX_PostMedias_UserId",
                table: "PostMedias");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4ff97448-2d30-45c6-a014-124bda3aafc3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bf4a90d7-63d6-4ee0-9475-4ace8aa7c5c7");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PostMedias");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3324), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3326) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3330), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3330) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3331), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3663), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3663) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3666), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(3666) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6714), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6717), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6718), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6718) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6725), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6725) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6726), new DateTime(2024, 3, 19, 3, 0, 10, 816, DateTimeKind.Utc).AddTicks(6726) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1307), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1309) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1314), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1314) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1315), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1316), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1317) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1317), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1318) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1319), new DateTime(2024, 3, 19, 3, 0, 10, 821, DateTimeKind.Utc).AddTicks(1320) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4ce6aebd-5511-4a91-9875-311b757cfbb1", "f7c65ff7-ba4e-4c2c-99b1-5a55768e3711", "Administrator", "ADMINISTRATOR" },
                    { "4d5ab5a0-5c73-4b44-a884-15a09601f478", "e9e08d41-a5da-441d-8380-195b8a4198d0", "User", "USER" }
                });
        }
    }
}
