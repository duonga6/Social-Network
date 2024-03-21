using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class update_postmedia_required_userId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4ff97448-2d30-45c6-a014-124bda3aafc3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "bf4a90d7-63d6-4ee0-9475-4ace8aa7c5c7");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PostMedias",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7330bae4-68a6-4c22-8feb-aee295f929d8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cd9f3f3d-7a27-4a0e-bcb7-9bf394ce2758");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "PostMedias",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
        }
    }
}
