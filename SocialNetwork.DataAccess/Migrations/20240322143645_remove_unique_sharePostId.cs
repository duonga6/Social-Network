using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class remove_unique_sharePostId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_SharePostId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7330bae4-68a6-4c22-8feb-aee295f929d8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cd9f3f3d-7a27-4a0e-bcb7-9bf394ce2758");

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
                name: "IX_Posts_SharePostId",
                table: "Posts",
                column: "SharePostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posts_SharePostId",
                table: "Posts");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0ffb7a32-699f-40f5-93b4-c51384f24c9a");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7d1f4af6-bab9-4a54-9327-f1b590a78da1");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3399), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3401) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3405), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3405) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3406), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3853), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3854) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3857), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(3857) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7879), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7880) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7883), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7883) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7884), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7884) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7885), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7885) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7886), new DateTime(2024, 3, 21, 15, 20, 32, 248, DateTimeKind.Utc).AddTicks(7886) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(240), new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(241) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(245), new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(245) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(246), new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(246) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(247), new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(247) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(248), new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(248) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(250), new DateTime(2024, 3, 21, 15, 20, 32, 254, DateTimeKind.Utc).AddTicks(251) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7330bae4-68a6-4c22-8feb-aee295f929d8", "eef4f7bf-d223-4a3b-9989-dbf6695810ee", "User", "USER" },
                    { "cd9f3f3d-7a27-4a0e-bcb7-9bf394ce2758", "41f7da05-582c-4754-8c6a-25dbdefe1177", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SharePostId",
                table: "Posts",
                column: "SharePostId",
                unique: true,
                filter: "[SharePostId] IS NOT NULL");
        }
    }
}
