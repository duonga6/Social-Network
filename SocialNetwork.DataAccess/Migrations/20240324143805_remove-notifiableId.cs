using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class removenotifiableId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c70e0566-9654-4d4b-9376-7a52b31ecc0e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dcaf9706-dbb3-4cc7-a0a5-65e4609df700");

            migrationBuilder.DropColumn(
                name: "NotifiableId",
                table: "Notifications");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "af2c6a21-fba2-438b-954b-0355d70a96d3");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "cd990cc3-2f64-4be1-87a3-1b6c2feb82c8");

            migrationBuilder.AddColumn<Guid>(
                name: "NotifiableId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9437), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9439) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9442), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9443), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9443) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9789), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9789) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9792), new DateTime(2024, 3, 24, 11, 52, 54, 57, DateTimeKind.Utc).AddTicks(9792) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2778), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2778) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2781), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2781) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2782), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2782) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2783), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2783) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2784), new DateTime(2024, 3, 24, 11, 52, 54, 58, DateTimeKind.Utc).AddTicks(2784) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7302), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7311), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7312) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7313), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7313) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7314), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7315) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7316), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7316) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7320), new DateTime(2024, 3, 24, 11, 52, 54, 65, DateTimeKind.Utc).AddTicks(7320) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c70e0566-9654-4d4b-9376-7a52b31ecc0e", "5e880f2d-d8ba-4c75-ac8b-295c4cd8ff75", "Administrator", "ADMINISTRATOR" },
                    { "dcaf9706-dbb3-4cc7-a0a5-65e4609df700", "9cdb7fd9-dfc1-41ef-a458-63b243680f75", "User", "USER" }
                });
        }
    }
}
