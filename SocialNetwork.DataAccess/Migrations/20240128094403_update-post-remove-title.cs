using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class updatepostremovetitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2407510a-9d32-42b8-a419-987b0274f10f");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fd34a429-fc8b-4772-9a29-735d4dc3b001");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4060), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4063) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4067), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4067) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4068), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4068) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4653), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4653) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4657), new DateTime(2024, 1, 28, 9, 44, 3, 103, DateTimeKind.Utc).AddTicks(4657) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7060), new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7063) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7067), new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7068) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7069), new DateTime(2024, 1, 28, 9, 44, 3, 106, DateTimeKind.Utc).AddTicks(7069) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8490), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8493) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8497), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8497) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8498), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8499), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8499) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8500), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8500) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8503), new DateTime(2024, 1, 28, 9, 44, 3, 110, DateTimeKind.Utc).AddTicks(8503) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "54f9c606-52d1-4de4-91ea-9e3e1dd34065", "06839c9c-3d7d-42ec-b0f3-582f9d02139b", "User", "USER" },
                    { "57e17f85-6e4f-4c1d-862b-3b0b52b4c2e6", "255e2137-bb85-4638-94c7-e63b7891e56d", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "54f9c606-52d1-4de4-91ea-9e3e1dd34065");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "57e17f85-6e4f-4c1d-862b-3b0b52b4c2e6");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Posts",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8754), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8756) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8760), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8761), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(8761) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(9136), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(9137) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(9139), new DateTime(2024, 1, 28, 3, 25, 42, 227, DateTimeKind.Utc).AddTicks(9139) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9533), new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9535) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9538), new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9539) });

            migrationBuilder.UpdateData(
                table: "MessageTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9539), new DateTime(2024, 1, 28, 3, 25, 42, 230, DateTimeKind.Utc).AddTicks(9540) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(947), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(949) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(953), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(953) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(954), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(955) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(956), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(956) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(957), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(957) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(960), new DateTime(2024, 1, 28, 3, 25, 42, 235, DateTimeKind.Utc).AddTicks(960) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2407510a-9d32-42b8-a419-987b0274f10f", "62ced3ab-11f8-4c56-89a8-bc3beeccb992", "User", "USER" },
                    { "fd34a429-fc8b-4772-9a29-735d4dc3b001", "c878fe12-2a31-4f8e-8da1-0aa5ef3e3bc6", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
