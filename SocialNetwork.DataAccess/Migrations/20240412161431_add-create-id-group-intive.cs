using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addcreateidgroupintive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dc448ed5-c0b6-4232-8499-72321ab8a0e5");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e0aeb98a-1ddf-470d-9591-fb9df0732347");

            migrationBuilder.AddColumn<string>(
                name: "CreatedId",
                table: "GroupInvites",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4210), new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4212) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4217), new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4217) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4218), new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4753), new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4758), new DateTime(2024, 4, 12, 16, 14, 30, 297, DateTimeKind.Utc).AddTicks(4758) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2619), new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2621) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2626), new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2626) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2627), new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2628) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2629), new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2629) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2630), new DateTime(2024, 4, 12, 16, 14, 30, 304, DateTimeKind.Utc).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(299), new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(302) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(307), new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(307) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(309), new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(309) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(322), new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(323) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(324), new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(324) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(328), new DateTime(2024, 4, 12, 16, 14, 30, 317, DateTimeKind.Utc).AddTicks(328) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1882c141-fa2e-4c37-8415-c79cae44e508", "157fd7c4-572f-4c57-a354-0dc5e5719428", "User", "USER" },
                    { "c3608bc7-b06c-47b3-bf20-8e72cb8008ea", "e9161ada-66bb-4546-8e09-16a4898dc98a", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GroupInvites_CreatedId",
                table: "GroupInvites",
                column: "CreatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupInvites_Users_CreatedId",
                table: "GroupInvites",
                column: "CreatedId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupInvites_Users_CreatedId",
                table: "GroupInvites");

            migrationBuilder.DropIndex(
                name: "IX_GroupInvites_CreatedId",
                table: "GroupInvites");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1882c141-fa2e-4c37-8415-c79cae44e508");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c3608bc7-b06c-47b3-bf20-8e72cb8008ea");

            migrationBuilder.DropColumn(
                name: "CreatedId",
                table: "GroupInvites");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7569), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7571) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7574), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7574) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7575), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7575) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7900), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7901) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7904), new DateTime(2024, 4, 12, 15, 36, 37, 481, DateTimeKind.Utc).AddTicks(7904) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6178), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6179) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6183), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6183) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6183), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6184) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6184), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6185) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6185), new DateTime(2024, 4, 12, 15, 36, 37, 482, DateTimeKind.Utc).AddTicks(6185) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5380), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5381) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5385), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5386) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5387), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5387) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5388), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5389) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5389), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5389) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5392), new DateTime(2024, 4, 12, 15, 36, 37, 490, DateTimeKind.Utc).AddTicks(5392) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dc448ed5-c0b6-4232-8499-72321ab8a0e5", "a0c8bb6c-83e7-4250-b121-587be92633de", "Administrator", "ADMINISTRATOR" },
                    { "e0aeb98a-1ddf-470d-9591-fb9df0732347", "1d6d80a5-ae05-4f32-b0a2-899e8671898a", "User", "USER" }
                });
        }
    }
}
