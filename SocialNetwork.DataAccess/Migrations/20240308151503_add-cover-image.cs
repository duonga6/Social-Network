using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addcoverimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b73274ae-1199-4d40-b1ae-37ae0faea91f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ed805820-4793-4c58-b18e-157509dfefa7");

            migrationBuilder.AddColumn<string>(
                name: "CoverImageUrl",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "47d4f135-c0aa-4af4-bd36-e7f2a1983b99");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b03c9b70-b84b-4bf3-85e5-96b44f30bd0f");

            migrationBuilder.DropColumn(
                name: "CoverImageUrl",
                table: "Users");

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
    }
}
