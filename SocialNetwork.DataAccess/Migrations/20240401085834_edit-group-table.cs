using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class editgrouptable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "11519cd8-48bc-43c8-b32c-aa09eb05fec7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a4f54938-50d4-45e0-9595-e2561cf8dee1");

            migrationBuilder.DropColumn(
                name: "OtherCanSee",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "PrivateGroup",
                table: "Groups",
                newName: "IsPublic");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6885), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6887) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6890), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6890) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6891), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(7390), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(7391) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(7394), new DateTime(2024, 4, 1, 8, 58, 33, 982, DateTimeKind.Utc).AddTicks(7394) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5932), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5933) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5936), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5936) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5937), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5937) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5938), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5938) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5939), new DateTime(2024, 4, 1, 8, 58, 33, 983, DateTimeKind.Utc).AddTicks(5939) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3639), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3640) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3644), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3644) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3646), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3646) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3647), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3647) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3648), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 4, 1, 8, 58, 33, 991, DateTimeKind.Utc).AddTicks(3651) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1aa7c567-9021-4910-9501-3f5dd5b9facb", "ea6d67d6-15d4-4e87-8a8e-1bc7a3f82d15", "Administrator", "ADMINISTRATOR" },
                    { "58c19c5a-cfad-4b23-be26-4bb2d5e8f76c", "e511da72-6ecd-4c73-a2c4-9577d9c76a75", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "1aa7c567-9021-4910-9501-3f5dd5b9facb");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "58c19c5a-cfad-4b23-be26-4bb2d5e8f76c");

            migrationBuilder.RenameColumn(
                name: "IsPublic",
                table: "Groups",
                newName: "PrivateGroup");

            migrationBuilder.AddColumn<bool>(
                name: "OtherCanSee",
                table: "Groups",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5249), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5255) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5258), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5258) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5259), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5259) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5758), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5761), new DateTime(2024, 3, 29, 2, 23, 5, 643, DateTimeKind.Utc).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4150), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4151) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4154), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4155), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4155) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4156), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4156) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4157), new DateTime(2024, 3, 29, 2, 23, 5, 644, DateTimeKind.Utc).AddTicks(4157) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(456), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(459) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(463), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(463) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(465), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(465) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(466), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(466) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(467), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(467) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(469), new DateTime(2024, 3, 29, 2, 23, 5, 652, DateTimeKind.Utc).AddTicks(469) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "11519cd8-48bc-43c8-b32c-aa09eb05fec7", "8026134d-37ab-4dd1-a059-626fc9d1bb22", "User", "USER" },
                    { "a4f54938-50d4-45e0-9595-e2561cf8dee1", "690cf795-4b08-4ef8-832e-5568456bd7cd", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
