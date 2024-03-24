using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class addpathcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "66c8fd3f-d386-4cd6-87fa-cc6790109150");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8a3e3843-a782-407c-93f6-9cdd21146303");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "PostComments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3060), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3063) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3065), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3066) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3067), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3067) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3403), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3404) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3406), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(3406) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6486), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6487) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6490), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6490) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6491), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6491) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6492), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6492) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6493), new DateTime(2024, 3, 24, 15, 9, 53, 273, DateTimeKind.Utc).AddTicks(6493) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5695), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5697) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5700), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5700) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5701), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5701) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5702), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5702) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5703), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5703) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5706), new DateTime(2024, 3, 24, 15, 9, 53, 280, DateTimeKind.Utc).AddTicks(5706) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "433bb76f-faf6-4a31-9aff-76eebf0ce46d", "34d42acc-059f-4426-8d7d-105815936f8b", "Administrator", "ADMINISTRATOR" },
                    { "69eba43c-fa05-4e64-91aa-35a6e035468c", "456aa9e4-9bd0-4b34-a51c-3e02e0e17438", "User", "USER" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "433bb76f-faf6-4a31-9aff-76eebf0ce46d");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "69eba43c-fa05-4e64-91aa-35a6e035468c");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "PostComments");

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
    }
}
