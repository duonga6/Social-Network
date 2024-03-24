using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addnotificableId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "af2c6a21-fba2-438b-954b-0355d70a96d3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cd990cc3-2f64-4be1-87a3-1b6c2feb82c8");

            migrationBuilder.RenameColumn(
                name: "NotifiableType",
                table: "Notifications",
                newName: "NotificationType");

            migrationBuilder.AddColumn<string>(
                name: "NotifiableId",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(3930), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(3933) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(3937), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(3938) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(3939), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(3939) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(4278), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(4278) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(4280), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(4280) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7515), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7516) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7520), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7520) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7525), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7526), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7526) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7527), new DateTime(2024, 3, 24, 14, 58, 55, 187, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8505), new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8510), new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8510) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8511), new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8512) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8512), new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8513), new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8514) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8516), new DateTime(2024, 3, 24, 14, 58, 55, 194, DateTimeKind.Utc).AddTicks(8516) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "66c8fd3f-d386-4cd6-87fa-cc6790109150", "d174b1d7-26f6-44e4-8dca-6c8f947346d7", "Administrator", "ADMINISTRATOR" },
                    { "8a3e3843-a782-407c-93f6-9cdd21146303", "e5c566d7-9f17-4232-b2dd-e53f81d9b59f", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "66c8fd3f-d386-4cd6-87fa-cc6790109150");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8a3e3843-a782-407c-93f6-9cdd21146303");

            migrationBuilder.DropColumn(
                name: "NotifiableId",
                table: "Notifications");

            migrationBuilder.RenameColumn(
                name: "NotificationType",
                table: "Notifications",
                newName: "NotifiableType");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(7595), new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(7597) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(7601), new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(7601) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(7602), new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(7602) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(8098), new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(8099) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(8102), new DateTime(2024, 3, 24, 14, 38, 4, 994, DateTimeKind.Utc).AddTicks(8102) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2024), new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2026) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2029), new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2030), new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2031) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2031), new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2032) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2032), new DateTime(2024, 3, 24, 14, 38, 4, 995, DateTimeKind.Utc).AddTicks(2033) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1247), new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1249) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1255), new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1255) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1256), new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1257) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1257), new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1258) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1258), new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1259) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1261), new DateTime(2024, 3, 24, 14, 38, 5, 9, DateTimeKind.Utc).AddTicks(1261) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "af2c6a21-fba2-438b-954b-0355d70a96d3", "7fee3391-2fd0-4773-8e8b-018943113880", "User", "USER" },
                    { "cd990cc3-2f64-4be1-87a3-1b6c2feb82c8", "6826a626-1bdf-4774-a0a4-d90986aa0697", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
