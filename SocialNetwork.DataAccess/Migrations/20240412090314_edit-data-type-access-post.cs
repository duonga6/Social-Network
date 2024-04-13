using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SocialNetwork.DataAccess.Migrations
{
    public partial class editdatatypeaccesspost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "4e2d5989-3cd1-4de1-a355-fb6680a1b5bd");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "602877f8-d863-42c1-8ccc-cd2d0c59b596");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5144), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5147) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5152), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5153), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5153) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5604), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5604) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5607), new DateTime(2024, 4, 12, 9, 3, 14, 79, DateTimeKind.Utc).AddTicks(5608) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4362), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4363) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4366), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4366) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4367), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4367) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4368), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4368) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4369), new DateTime(2024, 4, 12, 9, 3, 14, 80, DateTimeKind.Utc).AddTicks(4369) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5328), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5331) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5335), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5335) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5336), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5336) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5337), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5337) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5338), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5338) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5340), new DateTime(2024, 4, 12, 9, 3, 14, 88, DateTimeKind.Utc).AddTicks(5340) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9a8d4d98-9884-49b8-afe5-ce4863017c86", "6282aef9-9caf-4129-9df6-eec45df3f4a1", "User", "USER" },
                    { "c1203678-656a-423d-8b02-5be4e3b5fffc", "c667cf6e-f3c9-4040-acbd-abcf4c223f76", "Administrator", "ADMINISTRATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9a8d4d98-9884-49b8-afe5-ce4863017c86");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c1203678-656a-423d-8b02-5be4e3b5fffc");

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8522), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8524) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8528), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8528) });

            migrationBuilder.UpdateData(
                table: "FriendshipTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8529), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(8529) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(9096), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(9097) });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(9100), new DateTime(2024, 4, 12, 8, 20, 19, 660, DateTimeKind.Utc).AddTicks(9101) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9050), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9051) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9055), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9055) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9056), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9056) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9057), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9057) });

            migrationBuilder.UpdateData(
                table: "MediaTypes",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9058), new DateTime(2024, 4, 12, 8, 20, 19, 661, DateTimeKind.Utc).AddTicks(9058) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5070), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5078), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5078) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5080), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5080) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5081), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5081) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5082), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5082) });

            migrationBuilder.UpdateData(
                table: "Reactions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5085), new DateTime(2024, 4, 12, 8, 20, 19, 671, DateTimeKind.Utc).AddTicks(5085) });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4e2d5989-3cd1-4de1-a355-fb6680a1b5bd", "6f242ceb-1bed-4df5-9493-d0b3157587c4", "Administrator", "ADMINISTRATOR" },
                    { "602877f8-d863-42c1-8ccc-cd2d0c59b596", "f9f549df-36d7-4682-a801-d79731294816", "User", "USER" }
                });
        }
    }
}
