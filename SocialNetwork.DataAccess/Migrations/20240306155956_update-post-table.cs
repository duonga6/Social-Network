using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updateposttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "355f426e-0a3b-468c-b55f-9c63a9d363f8");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8820405d-d9d9-4ebf-af2c-dc5e62b5f9ee");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(MAX)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3092), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3093) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3097), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3097) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3098), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3098) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3377), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3377) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3381), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3381) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3813), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3813) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3817), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3817) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3818), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3819), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3819) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3819), new DateTime(2024, 3, 6, 15, 59, 55, 569, DateTimeKind.Utc).AddTicks(3820) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7280), new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7281) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7285), new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7286) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7287), new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7287) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7287), new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7288) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7288), new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7289) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7291), new DateTime(2024, 3, 6, 15, 59, 55, 575, DateTimeKind.Utc).AddTicks(7291) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b73274ae-1199-4d40-b1ae-37ae0faea91f", "30117b1f-0f55-4abb-bfbc-fa4a073e73f9", "User", "USER" },
                    { "ed805820-4793-4c58-b18e-157509dfefa7", "44d253ad-2b31-40e6-a7d0-6f7113ae157d", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b73274ae-1199-4d40-b1ae-37ae0faea91f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ed805820-4793-4c58-b18e-157509dfefa7");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Posts",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9878), new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9881) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9886), new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9886), new DateTime(2024, 2, 11, 6, 18, 8, 489, DateTimeKind.Utc).AddTicks(9887) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(166), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(166) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(202), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(203) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(475), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(476) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(479), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(479) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(480), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(481), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(481) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(482), new DateTime(2024, 2, 11, 6, 18, 8, 490, DateTimeKind.Utc).AddTicks(482) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6553), new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6556) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6560), new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6560) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6561), new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6561) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6562), new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6562) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6563), new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6563) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6565), new DateTime(2024, 2, 11, 6, 18, 8, 496, DateTimeKind.Utc).AddTicks(6566) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "355f426e-0a3b-468c-b55f-9c63a9d363f8", "fa051a0a-428b-4430-9612-b87af99b2c8d", "Administrator", "ADMINISTRATOR" },
                    { "8820405d-d9d9-4ebf-af2c-dc5e62b5f9ee", "3c360a0f-823e-464d-90d0-40dcd3d5c0ba", "User", "USER" }
                });
        }
    }
}
