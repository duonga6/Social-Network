using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addcolumnuseracceptgroupintive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1882c141-fa2e-4c37-8415-c79cae44e508");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c3608bc7-b06c-47b3-bf20-8e72cb8008ea");

            migrationBuilder.RenameColumn(
                name: "Accepted",
                table: "GroupInvites",
                newName: "UserAccepted");

            migrationBuilder.AddColumn<bool>(
                name: "AdminAccepted",
                table: "GroupInvites",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4188), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4192) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4197), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4197) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4198), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(4199) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(5291), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(5292) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(5296), new DateTime(2024, 4, 13, 2, 16, 11, 876, DateTimeKind.Utc).AddTicks(5297) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2574), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2577) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2581), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2582) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2583), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2584), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2584) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2585), new DateTime(2024, 4, 13, 2, 16, 11, 882, DateTimeKind.Utc).AddTicks(2585) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3541), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3547) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3551), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3551) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3553), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3553) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3554), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3555) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3556), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3556) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3558), new DateTime(2024, 4, 13, 2, 16, 11, 895, DateTimeKind.Utc).AddTicks(3558) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d26388c9-62e6-497a-b686-5e5d83a0ce4b", "4cf8b535-8e4a-4bc0-8be0-d5e9fee904ef", "User", "USER" },
                    { "edf1f3a4-a04d-415e-b12d-06ef5491b831", "0138ed82-c970-41bc-b3cd-dc5edba42243", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d26388c9-62e6-497a-b686-5e5d83a0ce4b");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "edf1f3a4-a04d-415e-b12d-06ef5491b831");

            migrationBuilder.DropColumn(
                name: "AdminAccepted",
                table: "GroupInvites");

            migrationBuilder.RenameColumn(
                name: "UserAccepted",
                table: "GroupInvites",
                newName: "Accepted");

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
        }
    }
}
